using UnityEngine;
using System.Collections;

public abstract class Switchable : MonoBehaviour {
    public Switchable target;
    private bool isLocked = false;
    protected GameObject locker;

    public GameObject Locker
    {
        get { return locker; }
    }

    public bool IsLocked
    {
        get { return isLocked; }
        set { isLocked = value; }
    }

    public void Lock(GameObject locker)
    {
        isLocked = true;
        this.locker = locker;
    }

    public void Unlock()
    {
        isLocked = false;
        this.locker = null;
    }

    abstract public Switchable GetTarget();
    abstract public void SetTarget(Switchable target);
    abstract public bool IsOn();
    abstract public void Toggle();
}
