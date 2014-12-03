using UnityEngine;
using System.Collections;

public class Switch : Switchable {

    public bool TurnedOn = false;
    public Transform transformOn;
    public Transform transformOff;
    public GameObject mesh;
    private float maxIntensity = 3.0f;
    private Vector3 desiredPosition = Vector3.zero;

    private float ToggleAnimSpeed = 0.2f;
    public GameObject lightFaker;
    private float desiredIntensity = 0;

    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        desiredPosition = transformOff.position;
	}

    void OnTriggerEnter(Collider collider)
    {
        if (!IsLocked && collider.tag == "Player" && !IsOn()) //Toggle on
        {
            Lock(collider.gameObject);
            Toggle();
            
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (!IsLocked && collider.tag == "Player" && !IsOn()) //Toggle on
        {
            Lock(collider.gameObject);
            Toggle();
            

        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == Locker && collider.tag == "Player" && IsOn()) //Toggle off
        {
            Toggle();
            Unlock();
            

        }
    }

	// Update is called once per frame
	void Update () {
        //Debug.Log(this.transformOff.position.ToString());
        //Debug.Log(this.transform.position.ToString());
        mesh.transform.position = Vector3.Lerp(mesh.transform.position, desiredPosition, ToggleAnimSpeed);
        lightFaker.light.intensity = Mathf.Lerp(lightFaker.light.intensity, desiredIntensity, 0.3f);
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
        return TurnedOn;
    }

    public override void Toggle()
    {
        TurnedOn = !TurnedOn;
        audio.Play();
        if (TurnedOn) //Turn on
        {
            desiredPosition = transformOn.position;
            if (Locker == null)
            {
                desiredIntensity = maxIntensity;
            }
        }
        else //Turn off
        {
            desiredPosition = transformOff.position;
            desiredIntensity = 0;
        }
        if (base.target != null)
        base.target.Toggle();
        
        if(locker && locker.tag != "Ghost")
            locker.GetComponent<CommandCollections>().addCommandOnOff(TurnedOn).button = this;
    }
}
