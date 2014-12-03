using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ghost : MonoBehaviour {
    List<ICommand> _commandList;
    public Vector3 Y;
    public List<ICommand> commandList 
    { 
        set 
        {
            _commandList = new List<ICommand>(value);
            foreach (ICommand command in _commandList)
                command.parent = gameObject;
        } 
    }

    List<ICommand>.Enumerator currentCommand;
    bool endOfList = true;
    public ParticleSystem buttonOn;
	// Use this for initialization
	void Start () {
        Y = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!endOfList)
            return;
        currentCommand.Current.execute();
        if (currentCommand.Current.isComplete)
        {
            Debug.Log(currentCommand.Current.GetType().Name);

            endOfList = currentCommand.MoveNext();
            currentCommand.Current.start();
        }

       // GetComponent<NavMeshAgent>().SetDestination(new Vector3(5.517384f, 1.823306f, -0.5983245f));

	}

    public void Respawn()
    {
        currentCommand = _commandList.GetEnumerator();
        currentCommand.MoveNext();
        endOfList = true;

        if (_commandList.Count > 2 && _commandList[_commandList.Count - 2] is CommandOnOff && ((CommandOnOff)_commandList[_commandList.Count - 2])._setOn == true && ((CommandOnOff)_commandList[_commandList.Count - 2]).isComplete == true)
        {

            if (((CommandOnOff)_commandList[_commandList.Count - 2])._setOn)
            {
                ((CommandOnOff)_commandList[_commandList.Count - 2]).button.Toggle();

                ((CommandOnOff)_commandList[_commandList.Count - 2]).button.Unlock();
                
            }
        }

        buttonOn.Stop();

        foreach (ICommand command in _commandList)
            command.isComplete = false;

        GetComponent<MeshRenderer>().enabled = true;

        transform.position = Y;
        //GetComponent<NavMeshAgent>().SetDestination(Y);
        //GetComponent<NavMeshAgent>().speed = 0;
    }
}
