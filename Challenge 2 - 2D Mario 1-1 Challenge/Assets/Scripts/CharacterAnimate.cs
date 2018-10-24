using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimate : MonoBehaviour {

    private Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") != 0){
            anim.SetBool("IsRunning", true);
        }else{
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetTrigger("Jump");

        }
    }
}
