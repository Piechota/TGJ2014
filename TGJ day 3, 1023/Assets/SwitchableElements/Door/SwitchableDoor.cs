using UnityEngine;
using System.Collections;

public class SwitchableDoor : Switchable {
    public bool doorOpened = false;
    public Transform openedTransform;
    private Vector3 closedLocation;
    private Vector3 desiredLocation = Vector3.zero;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        closedLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        desiredLocation = closedLocation;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, desiredLocation, 0.2f);
        if (transform.position == desiredLocation)
            audio.Stop();

        if ((rigidbody != null) && rigidbody.IsSleeping())
        {
            rigidbody.WakeUp();
        }
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
        return doorOpened;
    }

    public override void Toggle()
    {
        doorOpened = !doorOpened;
        if (doorOpened)
        {
            desiredLocation = openedTransform.position;
            audio.Play();
        }
        else
        {
            audio.Play();
            desiredLocation = closedLocation;
        }

        if (target != null)
            target.Toggle();
    }

}
