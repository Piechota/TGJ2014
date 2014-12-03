using UnityEngine;
using System.Collections;

public class SwitchableBlade : Switchable {

    public bool _on;
    bool _stop;
    Vector3 _stopVector;

    float _time;
    public Transform stopTransform;
    public float rotateSpeed;
    public float maxAngle;
    float currentAngle;

    public bool side;
    int _side { get { if (side) return 1; return -1; } }
    Quaternion tmp;
    // Use this for initialization
    void Start()
    {
        tmp = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        _stop = false;
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_stop)
            return;
        if (!_on)
        {
            _time += Time.deltaTime/3;

            float dAngle = Mathf.Sin(_time * (rotateSpeed)) * maxAngle * _side;
            if (Mathf.Abs(maxAngle - Mathf.Abs(dAngle)) < 5)
            {
                _stop = true;
                return;
            }
            transform.rotation = tmp;
            transform.Rotate(0, 0, dAngle);

            return;
        }
        _time += Time.deltaTime;
        float Angle = Mathf.Sin(_time * rotateSpeed) * maxAngle * _side;
        transform.rotation = tmp;
        transform.Rotate(0, 0, Angle);

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
        return _on;
    }

    public override void Toggle()
    {
        
        _on = !_on;
        _stop = false;

        if(target)
        target.Toggle();
    }
}
