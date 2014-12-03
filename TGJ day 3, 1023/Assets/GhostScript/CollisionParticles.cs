using UnityEngine;
using System.Collections;

public class CollisionParticles : MonoBehaviour {
    public ParticleSystem explosionParticles;
    
	// Use this for initialization
	void Start () {
	    
	}

    void OnTriggerEnter(Collider col)
    {
        explosionParticles.Play();
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
