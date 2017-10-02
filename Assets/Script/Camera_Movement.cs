using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

	public float panSpeed = 20f;
	public float panBorderThickness = 10f;
	public Vector2 Screen_Limit;

	public float scrollSpeed = 200f;
	public float minY = 20f;
	public float maxY = 50f;

	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){

			pos.z += panSpeed * Time.deltaTime;

		}

		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){

			pos.z -= panSpeed * Time.deltaTime;

		}

		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness){

			pos.x += panSpeed * Time.deltaTime;

		}

		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness){

			pos.x -= panSpeed * Time.deltaTime;

		}

		float Scroll = Input.GetAxis("Mouse ScrollWheel");

		pos.y += Scroll * scrollSpeed * Time.deltaTime;


		pos.x = Mathf.Clamp(pos.x, -Screen_Limit.x, Screen_Limit.x);
		pos.z = Mathf.Clamp(pos.z, -Screen_Limit.y, Screen_Limit.y);

		pos.y = Mathf.Clamp(pos.y, minY, maxY);

		transform.position = pos;
	}
}
