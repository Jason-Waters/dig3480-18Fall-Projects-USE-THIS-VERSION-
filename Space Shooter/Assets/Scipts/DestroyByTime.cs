using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float lifetime;
	
	// Update is called once per frame
	void Start () {
        Destroy(gameObject, lifetime);
	}
}
