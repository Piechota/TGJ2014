using UnityEngine;
using System.Collections;

public class SwitchableTrash : Switchable
{
    bool _isOn;
    public Transform topPoint;
    public Vector3 bottomPoint;
    public float speed = 0.1f;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        bottomPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (_isOn && transform.position != topPoint.position)
                transform.position = Vector3.Lerp(transform.position, topPoint.position, speed);
        if (!_isOn && transform.position != bottomPoint)
            transform.position = Vector3.Lerp(transform.position, bottomPoint, speed);
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
        return _isOn;
    }

    public override void Toggle()
    {
        _isOn = !_isOn;
        audio.Play();
        if (target)
            target.Toggle();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (transform.position == bottomPoint || _isOn)
            return;
        CommandCollections player = collider.GetComponent<CommandCollections>();
        if (player)
            player.ResetLevel();
    }
}
