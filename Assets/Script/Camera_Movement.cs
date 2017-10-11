using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

	public float panSpeed = 20f;
	public float panBorderThickness = 10f;
	public Vector2 Screen_Limit;

	public float x_Left_and_right = 15f;

	public float scrollSpeed = 200f;
	public float minY;
	public float maxY;
	public float close_Z = -15f;
	public float far_Z = -30f;

	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){

			pos.y += panSpeed * Time.deltaTime;

		}

		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){

			pos.y -= panSpeed * Time.deltaTime;

		}

		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness){

			pos.x += panSpeed * Time.deltaTime;

		}

		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness){

			pos.x -= panSpeed * Time.deltaTime;

		}

		float Scroll = Input.GetAxis("Mouse ScrollWheel");

		pos.z += Scroll * scrollSpeed * Time.deltaTime;

		if(pos.z >= far_Z){
			pos.y = Mathf.Clamp(pos.y, -(Mathf.Abs(minY)+(Mathf.Abs(far_Z)-Mathf.Abs(pos.z))/Mathf.Sqrt(3f)), 
				Mathf.Abs(maxY)+(Mathf.Abs(far_Z)-Mathf.Abs(pos.z))/Mathf.Sqrt(3f));
		}

		if(pos.z >= far_Z){
			//print("1 : " + (Mathf.Abs(far_Z)-Mathf.Abs(pos.z))/Mathf.Sqrt(3f));
			//print("2 : " + (Mathf.Abs(far_Z)/Mathf.Sqrt(3f) - Mathf.Abs(pos.z)/Mathf.Sqrt(3f)));
			pos.x = Mathf.Clamp(pos.x, -(x_Left_and_right + (Mathf.Abs(far_Z)-Mathf.Abs(pos.z))/Mathf.Sqrt(3f)), 
				(x_Left_and_right + (Mathf.Abs(far_Z)-Mathf.Abs(pos.z))/Mathf.Sqrt(3f)));
		}

		pos.z = Mathf.Clamp(pos.z, far_Z, close_Z);

		transform.position = pos;
	}
}
