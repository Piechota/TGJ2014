using UnityEngine;
using System.Collections;

public class SwitchableLight : Switchable  {
    public bool LightOn = false;
    private float MaxIntensity;
    private float DesiredIntensity = 0;

	// Use this for initialization
	void Start () {
        MaxIntensity = light.intensity;
        light.intensity = DesiredIntensity;
	}
	
	// Update is called once per frame
	void Update () {
        light.intensity = Mathf.Lerp(light.intensity, DesiredIntensity, 0.3f);
	}

    public override Switchable GetTarget()
    {
        return null;
    }

    public override void SetTarget(Switchable target)
    {
        this.target = target;
    }

    public override bool IsOn()
    {
        return LightOn;
    }

    public override void Toggle()
    {
        LightOn = !LightOn;

        if (LightOn) //Turn on
        {
            DesiredIntensity = MaxIntensity;
        }
        else //Turn off
        {
            DesiredIntensity = 0.0f;
        }
        
        if (target != null)
            target.Toggle();
    }
}
