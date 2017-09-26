using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Planet_Rotation : MonoBehaviour {

	public float Mass_Modify;

	public float Constant_G = 1f;

	public float Multiply;

	private Rigidbody rock;

	private List<Vector3> planet_position;

	private List<float> planet_mass;

	private List<float> planet_Multiplication;

	private bool enter_Range = false;
	private bool collider_planet = false;

	private bool Win = false;

	public GameObject Menu;
	public GameObject Win_MSG;

	// Use this for initialization
	void Start () {
		rock = GetComponent<Rigidbody>();

		planet_position = new List<Vector3>();
		planet_mass = new List<float>();
		planet_Multiplication = new List<float>();
	}


	void FixedUpdate (){
		
		//The main function for compute gravitational force
		if (enter_Range && !collider_planet){

			//No function !!!
			//Vector3[] force_value = new Vector3[planet_position.Count];

			for(int i = 0; i < planet_position.Count; i++){

				float planet_m = planet_mass[i];
				//print("Plan_Mass : " + planet_m);

				float r = Vector3.Magnitude(transform.position - planet_position[i]);
				float totalForce = -(Constant_G * planet_m * rock.mass) / (r * r);
				Vector3 force = -(planet_position[i] - transform.position).normalized * totalForce;

				//print ("Plan_Pos : " + totalForce);

				rock.AddForce(force * planet_Multiplication[i], ForceMode.Force);

				planet_Multiplication[i] += Time.deltaTime * 1.05f;

				//print("Multi : " + planet_Multiplication[i]);
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
			rock.Sleep();
		}

		if(Win){
			Menu.SetActive(true);
			Win_MSG.SetActive(true);
		}

	}

	//Entering Gravitational Range
	void OnTriggerStay(Collider Col){


		if(Col.gameObject.tag == "Range"){
			//print("true");

			enter_Range = true;

			Transform temp_pos = Col.GetComponentInParent<Transform>().transform;
			float temp_mass = Col.GetComponentInParent<Rigidbody>().mass;

			//Trigger On atmo change
			Col.gameObject.GetComponent<Atmosphere>().change_Color_Trigger = true;

			if(!planet_position.Contains(temp_pos.position) && !Win){
				planet_position.Add(temp_pos.position);
				planet_mass.Add(temp_mass);
				planet_Multiplication.Add(Multiply);

				//print("Collider planet mass : " + temp_mass);
				print("List len: " + planet_position.Count);
			}



		}else
			enter_Range = false;

	}

	void OnTriggerExit(Collider col){
		enter_Range = false;
		if(col.gameObject.tag == "Range")
			col.gameObject.GetComponent<Atmosphere>().change_Color_Trigger = false;


	}

	//Collide with planet
	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "planet"){
			//print("true1");
			collider_planet = true;
		}

		else if(col.gameObject.tag == "Target"){
			Win = true;
			collider_planet = true;
		}

	}
}
