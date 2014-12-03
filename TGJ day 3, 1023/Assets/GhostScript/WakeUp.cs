using UnityEngine;
using System.Collections;

public class WakeUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((rigidbody != null) && rigidbody.IsSleeping())
        {
            rigidbody.WakeUp();
        }
	}
}
