using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Rotation : MonoBehaviour {

	public Transform Sun_rotation;

	public float Constant_G = 1f;

	public float Multiply;

	private Rigidbody planet;

	public float Sun_mass;
	public string Object_name;

	private bool enter_Range = false;

	// Use this for initialization
	void Start () {
		planet = GetComponent<Rigidbody>();

		//Sun_mass = GameObject.Find(Object_name).GetComponent<Rigidbody>().mass;
		/*Sun_mass = 100f;
		float initV = Mathf.Sqrt(2f * Constant_G * Sun_mass / planet.position.magnitude);
		GetComponent<Rigidbody>().velocity = new Vector3(initV * 2f, 0, 0);*/
	}
		
	
	void FixedUpdate (){

		if(enter_Range){

			float r = Vector3.Magnitude(transform.position);
			float totalForce = -(Constant_G * Sun_mass * planet.mass) / (r * r);
			Vector3 force = -(Sun_rotation.position - transform.position).normalized * totalForce;

			//print (force );

			GetComponent<Rigidbody>().AddForce(force * Multiply, ForceMode.Force);

		}

	}

	void OnTriggerEnter(Collider Col){


		if(Col.gameObject.tag == "Range"){
			print("true");
			enter_Range = true;
			Sun_mass = Col.GetComponentInParent<Rigidbody>().mass;
			Sun_rotation = Col.GetComponentInParent<Transform>().transform;
			print(Sun_mass);
		}else
			enter_Range = false;

	}
}
