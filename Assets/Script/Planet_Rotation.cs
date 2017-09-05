using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Planet_Rotation : MonoBehaviour {

	public float Constant_G = 1f;

	public float Multiply;

	private Rigidbody planet;

	//public float Sun_mass;

	private List<Vector3> planet_position;

	private List<float> planet_mass;

	private string Object_name;

	private bool enter_Range = false;
	private bool collider_planet = false;


	// Use this for initialization
	void Start () {
		planet = GetComponent<Rigidbody>();

		planet_position = new List<Vector3>();
		planet_mass = new List<float>();

		//Sun_mass = GameObject.Find(Object_name).GetComponent<Rigidbody>().mass;
		/*Sun_mass = 100f;
		float initV = Mathf.Sqrt(2f * Constant_G * Sun_mass / planet.position.magnitude);
		GetComponent<Rigidbody>().velocity = new Vector3(initV * 2f, 0, 0);*/
	}
		
	
	void FixedUpdate (){

		//The main function for compute gravitational force
		if (enter_Range && !collider_planet){

			//No function !!!
			//Vector3[] force_value = new Vector3[planet_position.Count];

			for(int i = 0; i < planet_position.Count; i++){

				//print("exe");

				float planet_m = planet_mass[i];
				print("Plan_Mass : " + planet_m);

				float r = Vector3.Magnitude(transform.position);
				float totalForce = -(Constant_G * planet_m * planet_m) / (r * r);
				Vector3 force = -(planet_position[i] - transform.position).normalized * totalForce;

				//print ("Plan_Pos : " + totalForce);

				//force_value[i] += force;
				GetComponent<Rigidbody>().AddForce(force * Multiply, ForceMode.Force);

			}

			//Test Function
			/*Vector3 final_force = new Vector3(0f, 0f, 0f);
			foreach(Vector3 i in force_value){

				final_force += i;

			}
			print("Final force : " + final_force);
			GetComponent<Rigidbody>().AddForce(final_force * Multiply, ForceMode.Force);*/
		}

		//If Collider with planet stop rigidbody
		if(collider_planet){
			planet = GetComponent<Rigidbody>();
			planet.Sleep();
		}

	}

	//Entering Gravitational Range
	void OnTriggerStay(Collider Col){


		if(Col.gameObject.tag == "Range"){
			//print("true");

			enter_Range = true;

			Transform temp_pos = Col.GetComponentInParent<Transform>().transform;
			float temp_mass = Col.GetComponentInParent<Rigidbody>().mass;


			if(!planet_position.Contains(temp_pos.position)){
				planet_position.Add(temp_pos.position);
				planet_mass.Add(temp_mass);

				print("Collider planet mass : " + temp_mass);
				print("List len: " + planet_position.Count);
			}
			
				

		}else
			enter_Range = false;

	}

	//Collide with planet
	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "planet"){
			//print("true1");
			collider_planet = true;
		}

	}
}
