using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Physics : MonoBehaviour {

	public bool Force = true;

	private Rigidbody rb;

	private int itr = 0;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){

		itr++;

		if (itr <= 5){
			rb.AddForce(new Vector3(0f, 0f, 1f), ForceMode.Force);
			rb.AddForce(new Vector3(1f, 0f, 0f), ForceMode.Force);
			return;
		}
		Force = false;

		//rb.AddForce(new Vector3(0f, 0f, 1f), ForceMode.Force);
	}

}
