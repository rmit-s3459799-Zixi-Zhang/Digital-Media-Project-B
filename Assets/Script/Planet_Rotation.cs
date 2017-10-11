using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Planet_Rotation : MonoBehaviour {

	//public float Mass_Modify;

	public float Constant_G = 1f;

	public float Multiply;

	private Rigidbody rock;

	private List<Vector3> planet_position;

	private List<float> planet_mass;

	private List<float> planet_Multiplication;

	private List<Vector3> planet_push_pos;
	private List<float> planet_push_mass;

	private bool enter_Range = false;
	private bool collider_planet = false;
	private int sceneIdex;
	private bool Win = false;
	private bool out_of_boundry = false;

	public GameObject Menu;
	public GameObject Win_MSG;
	private Scene scene;

	//public Vector2[] Border;

	// Use this for initialization
	void Start () {
		rock = GetComponent<Rigidbody>();
		sceneIdex = SceneManager.GetActiveScene().buildIndex;
		planet_position = new List<Vector3>();
		planet_mass = new List<float>();
		planet_Multiplication = new List<float>();

		planet_push_pos = new List<Vector3>();
		planet_push_mass = new List<float>();
	}


	void FixedUpdate (){
		
		//The main function for compute gravitational force
		if (!collider_planet){

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

			for(int i = 0; i < planet_push_pos.Count; i++){

				float planet_m = planet_push_mass[i];

				float r = Vector3.Magnitude(transform.position - planet_push_pos[i]);
				float totalForce = -(Constant_G * planet_m * rock.mass) / (r * r);
				Vector3 force = (planet_push_pos[i] - transform.position).normalized * totalForce;

				rock.AddForce(force * 5.0f, ForceMode.Force);

			}
		}

		//If Collider with planet stop rigidbody
		if(collider_planet){
			rock.Sleep();
			GameObject.Find("PausedMenu").GetComponent<Button>().Pause();
		}

		if(Win){
			Menu.SetActive(true);
			Win_MSG.SetActive(true);
			GameManager.instance.levelClear[sceneIdex-1] = true;
		}

		/*if(transform.position.x <= Border[0].x || transform.position.x >= Border[1].x
			|| transform.position.y <= Border[1].y || transform.position.y >= Border[0].y ){
			GameObject.Find("PausedMenu").GetComponent<Button>().Pause();
		}*/
		if(out_of_boundry){
			GameObject.Find("PausedMenu").GetComponent<Button>().Pause();
			out_of_boundry = false;
		}
	}

	//Entering Gravitational Range
	void OnTriggerStay(Collider Col){


		if(Col.gameObject.tag == "Range"){
			//print("true");

			//enter_Range = true;

			Transform temp_pos = Col.GetComponentInParent<Transform>().transform;
			float temp_mass = Col.GetComponentInParent<Rigidbody>().mass;

			//Trigger On atmo change
			Col.gameObject.GetComponent<Atmosphere>().change_Color_Trigger = true;

			if(!planet_position.Contains(temp_pos.position) && !Win){
				planet_position.Add(temp_pos.position);
				planet_mass.Add(temp_mass);
				planet_Multiplication.Add(Multiply);

				//print("Collider planet mass : " + temp_mass);
				print("List len Pos: " + planet_position.Count);

			}



		}

		if(Col.gameObject.tag == "Push"){

			Transform temp_pos = Col.GetComponentInParent<Transform>().transform;
			float temp_mass = Col.GetComponentInParent<Rigidbody>().mass;

			//Trigger On atmo change
			Col.gameObject.GetComponent<Atmosphere>().change_Color_Trigger = true;

			if(!planet_push_pos.Contains(temp_pos.position) && !Win){

				planet_push_pos.Add(temp_pos.position);
				planet_push_mass.Add(temp_mass);

				print("Push List len : " + planet_push_pos.Count);

			}

		}

	}

	void OnTriggerExit(Collider col){
		//enter_Range = false;

		if(col.gameObject.tag == "Range"){

			col.gameObject.GetComponent<Atmosphere>().change_Color_Trigger = false;

			Transform temp_pos = col.GetComponentInParent<Transform>().transform;
			//float temp_mass = col.GetComponentInParent<Rigidbody>().mass;

			//Find index
			int i = planet_position.IndexOf(temp_pos.position);

			//Remove from list
			planet_position.RemoveAt(i);
			planet_mass.RemoveAt(i);
			planet_Multiplication.RemoveAt(i);

			print("-List len Pos: " + planet_position.Count);
			//print("-List len Mas: " + planet_mass.Count);
			//print("-List len Mul: " + planet_Multiplication.Count);

		}

		if(col.gameObject.tag == "Push"){

			col.gameObject.GetComponent<Atmosphere>().change_Color_Trigger = false;

			Transform temp_pos = col.GetComponentInParent<Transform>().transform;
			//float temp_mass = col.GetComponentInParent<Rigidbody>().mass;

			//Find index
			int i = planet_push_pos.IndexOf(temp_pos.position);

			//Remove from list
			planet_push_pos.RemoveAt(i);
			planet_push_mass.RemoveAt(i);

			print("-Push len : " + planet_push_pos.Count);
		}

	}

	//Collide with planet
	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "planet"){
			//print("true1");
			collider_planet = true;
		}

		if(col.gameObject.tag == "Target"){
			Win = true;
			collider_planet = true;
		}

		if(col.gameObject.tag == "Border"){
			out_of_boundry = true;
		}

		if(col.gameObject.tag == "Rock"){
			collider_planet = true;
		}

	}
}
