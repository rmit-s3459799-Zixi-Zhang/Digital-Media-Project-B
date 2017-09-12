using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour 
{ 
	private Vector3 screenPos;
	public float speed;
	public float maxSpeed;
	private Rigidbody rb;
	private Vector3 shootDirection;
	private bool isflying;
	private Slider powerBar;
	public float value;
	private float rate;

	private bool On_Button;

	void Awake()
	{
		
	}
	void Start () {
		
		isflying = false;
		powerBar= GameObject.Find("Power").GetComponent<Slider>();
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		Mouse_function();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast(ray, out hit)) {

			if (hit.collider.gameObject.tag != "Button"){
				
			}
				
		}
	}

	void Mouse_function(){

		Vector3 mousePosition = Input.mousePosition;
		Debug.DrawLine (rb.position, mousePosition, Color.red);

		rb.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x))*Mathf.Rad2Deg - 90);
		if(speed <= 0)
		{
			rate = 1;
		}
		if (speed >= maxSpeed) {
			rate = -1;
		}
		if (Input.GetMouseButton(0) && isflying==false) {
			speed = speed + (Time.deltaTime * rate); 
			powerBar.value = speed;

		}
		if (Input.GetMouseButtonUp(0) && isflying==false) {
			shootDirection = mousePosition - rb.transform.position;
			rb.velocity = new Vector2 (shootDirection.x * speed / value, shootDirection.y * speed / value);
			isflying = true;
			powerBar.value = 0;
		}
	}

	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(myLine, duration);
	}
		
}