using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour 
{ 
	public Camera camera;
	private Vector3 screenPos;
	public float speed;
	private Rigidbody rb;
	private Vector3 shootDirection;

	void Awake()
	{
		
	}
	void Start () {
		

	}
	void FixedUpdate() {
		rb = GetComponent<Rigidbody>();
		Vector3 mousePosition = Input.mousePosition;

		//screenPos = camera.ScreenToWorldPoint(Vector3(mousePosition.x, mousePosition.y, transform.position.z - camera.main.transform.position.z));
		rb.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x))*Mathf.Rad2Deg - 90);


		//Vector3 worldpos = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mousePosition.z));
	 	//rb.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg - 90);
		//Vector3 turretLookDirection = new Vector3 (worldpos.x,rb.transform.position.y, worldpos.z);
		//rb.transform.LookAt(turretLookDirection);
		print (mousePosition);
		if (Input.GetMouseButton (0)) {
			
			shootDirection = mousePosition;
			shootDirection = shootDirection - rb.transform.position;
			rb.velocity = new Vector2 (shootDirection.x * speed, shootDirection.y * speed);
		}
	}
}