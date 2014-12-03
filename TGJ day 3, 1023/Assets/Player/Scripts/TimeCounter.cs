using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {
    public float TimeForLevel = 2.0f;
    float _currentTime;
    float currentTime { set { _currentTime = value; } get { return _currentTime / 60; } }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
        if (currentTime > TimeForLevel)
            GetComponent<CommandCollections>().ResetLevel();
	}
}
