using UnityEngine;
using System.Collections;

public class SwitchablePistons : Switchable
{
    public bool isOn;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 0.25f;
    AudioSource audio;


	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isOn && transform.position != endPoint.position)
            transform.position = Vector3.Lerp(transform.position, endPoint.position, speed);
        if (!isOn && transform.position != startPoint.position)
            transform.position = Vector3.Lerp(transform.position, startPoint.position, speed);
	}

    public override Switchable GetTarget()
    {
        return target;
    }

    public override void SetTarget(Switchable target)
    {
        this.target = target;
    }

    public override bool IsOn()
    {
        return isOn;
    }

    public override void Toggle()
    {
        isOn = !isOn;
        audio.Play();
        if (target)
            target.Toggle();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (transform.position != endPoint.position)
            return;
        CommandCollections player = collider.GetComponent<CommandCollections>();
        if (player)
            player.ResetLevel();
    }
}
