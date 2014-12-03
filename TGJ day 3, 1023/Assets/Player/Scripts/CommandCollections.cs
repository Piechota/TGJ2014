using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandCollections : MonoBehaviour
{
    List<ICommand> commandStack;
    List<Ghost> ghostList;

    public Vector3 startPosition;
    Quaternion startRotation;
    float lastTime;

    public Camera death;
    public Camera normal;

    RandomStart start;

    bool isRestart = false;

    public GameObject GhostPrefab;
    // Use this for initialization
    void Start()
    {
        commandStack = new List<ICommand>();
        ghostList = new List<Ghost>();
        start = GameObject.FindGameObjectWithTag("Start").GetComponent<RandomStart>();
        startRotation = transform.rotation;
        startPosition = start.transform.position;

        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (commandStack.Count > 1 && isRestart && commandStack[commandStack.Count - 1] is CommandOnOff)
        {
            if (commandStack[commandStack.Count - 1].time < 0.1f)
                commandStack.RemoveAt(commandStack.Count - 1);
            isRestart = false;

        }

        if (Input.GetKeyDown(KeyCode.R))
            Die();

        if (Input.GetKeyDown(KeyCode.T))
            startPosition = transform.position;

        if (death.active == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Application.LoadLevel(Application.loadedLevel);

                Time.timeScale = 1.0f;

            }
        }
    }


    void Respawn()
    {

        CommandRespawn res = new CommandRespawn();
        res.endPosition = startPosition;
        res.time = 0;
        res.parent = gameObject;
        commandStack.Add(res);

        lastTime = Time.fixedTime;

        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    void Die()
    {
        isRestart = true;
        CommandDie die = new CommandDie();
        die.endPosition = transform.position;

        if (commandStack[commandStack.Count - 1] is CommandOnOff && ((CommandOnOff)commandStack[commandStack.Count - 1])._setOn == true)
        {
            Vector3 pos = ((CommandOnOff)commandStack[commandStack.Count - 1]).button.transform.position;
            die.endPosition = new Vector3(pos.x, transform.position.y, pos.z);
        }
        die.parent = gameObject;
        die.time = Time.fixedTime - lastTime;
        commandStack.Add(die);

        GameObject newGhost = Instantiate(GhostPrefab, startPosition, startRotation) as GameObject;
        newGhost.GetComponent<Ghost>().commandList = commandStack;
        ghostList.Add(newGhost.GetComponent<Ghost>());
        Debug.Log("***");
        foreach (Ghost ghost in ghostList)
            ghost.Respawn();

        commandStack.Clear();
        Respawn();
    }

    public void ResetLevel()
    {
        normal.active = false;
        death.active = true;
        Time.timeScale = 0.0f;
        //while (!Input.GetKeyDown(KeyCode.Space)) { }
        //Application.LoadLevel(Application.loadedLevel);
        //normal.enabled = true;
        //death.enabled = false;
    }

    public CommandOnOff addCommandOnOff(bool isOn)
    {
        CommandOnOff OnOff = new CommandOnOff();
        OnOff.endPosition = transform.position;
        OnOff.parent = gameObject;
        OnOff.time = Time.fixedTime - lastTime;
        OnOff.setOn = isOn;
        commandStack.Add(OnOff);

        lastTime = Time.fixedTime;

        return OnOff;
    }
}
