using UnityEngine;
using System.Collections;

public class GroundCheckerScript : MonoBehaviour {
    public bool Grounded = false;


    void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "Player")
        {
            Grounded = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag != "Player")
        {
            Grounded = false;
        }
    }
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
