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
	public float Multiplyer;
	private float rate;

	private bool On_Button = false;

	private LineRenderer lr;

	private bool Mouse_tri = false;

	void Awake()
	{
		
	}
	void Start () {
		
		isflying = false;
		powerBar= GameObject.Find("Power").GetComponent<Slider>();
		rb = GetComponent<Rigidbody>();
		lr = GetComponent<LineRenderer>();
	}

	void FixedUpdate() {
		
		if(!On_Button){
			float z = Camera.main.transform.position.z;
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -z));
			//mousePosition.z = 0;
			//Vector3 mousePosition = Input.mousePosition;
			//Debug.DrawLine (rb.position, mousePosition, Color.red);
			//print (rb.transform.position);
			DrawLine(transform.position, mousePosition);

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
				Mouse_tri = true;
			}
			/*if (Input.GetMouseButtonUp(0) && isflying==false) {
				shootDirection = mousePosition - rb.transform.position;
				rb.velocity = new Vector2 (shootDirection.x * speed / value, shootDirection.y * speed / value);
				isflying = true;
				powerBar.value = 0;
			}*/
			if (Mouse_tri && !isflying && !Input.GetMouseButton(0)){


				shootDirection = mousePosition - rb.transform.position;

				float n = Mathf.Sqrt ((shootDirection.x * shootDirection.x) + (shootDirection.y * shootDirection.y));
				shootDirection.x = shootDirection.x / n;
				shootDirection.y = shootDirection.y / n;


				rb.velocity = new Vector2 (shootDirection.x * speed * Multiplyer, shootDirection.y * speed * Multiplyer);
				isflying = true;
				powerBar.value = 0;
			}

		}




	}

	void DrawLine(Vector3 start, Vector3 end)
	{
		//print(end);

		Vector3 tmp = end - start;
		float angle = Mathf.Atan2 (tmp.y, tmp.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		Color init_color = Color.red;
		if(!isflying){
			//GameObject myLine = new GameObject();
			//myLine.transform.position = start;
			//myLine.AddComponent<LineRenderer>();
			//LineRenderer lr = myLine.GetComponent<LineRenderer>();
			//lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
			//lr.SetColors(color, color);
			//lr.SetWidth(0.1f, 0.1f);
			lr.startColor = init_color;
			lr.startWidth = 0.3f;
			lr.endWidth = 0.2f;
			//lr.SetPosition(0, tmp);
			//lr.SetPosition(1, tmp1);
			lr.useWorldSpace = true;
			lr.SetPosition(0, start);
			lr.SetPosition(1, end);
		}else{
			lr.enabled = false;
		}

		 tmp = end -start;

	}

	/*void OnGUI(){

		DrawLine1((Vector2)transform.position, (Vector2)Input.mousePosition, 100);
	}

	private void DrawLine1(Vector2 start, Vector2 end, int width)
	{
		Vector2 d = start - end;
		float a = Mathf.Rad2Deg * Mathf.Atan(d.y / d.x);
		if (d.x < 0)
			a += 180;

		int width2 = (int) Mathf.Ceil(width / 2);

		//GUIUtility.RotateAroundPivot(a, end);
		//GUI.DrawTexture(new Rect(transform.position.x, end.y - width2, d.magnitude, width), arrow);
		//GUIUtility.RotateAroundPivot(-a, start);

		Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.DrawTexture(new Rect(transform.position.x, Screen.height - objPos.y, 200, 100), arrow);
		//GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 200,100), arrow);
	}*/

	public void Mouse_On_Button(){
		On_Button = true;
	}

	public void Mouse_Exit(){
		On_Button = false;
	}

}