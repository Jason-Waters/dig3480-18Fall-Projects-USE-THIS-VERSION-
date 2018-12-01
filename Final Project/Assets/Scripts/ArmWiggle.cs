﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmWiggle : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            anim.SetBool("AddPush", true);
        }
	}
}
