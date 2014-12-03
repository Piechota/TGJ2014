using UnityEngine;
using System.Collections;

public class RandomStart : MonoBehaviour {
    BoxCollider box;
	// Use this for initialization
	void Start () {
        box = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector3 randomPoint()
    {
        Vector3 returned = transform.position;

        Vector2 offset;
        offset.x = Random.RandomRange(-box.size.x, box.size.x);
        offset.y = Random.RandomRange(-box.size.z, box.size.z);

        returned.x += offset.x;
        returned.z += offset.y;

        return returned;
    }
}
