using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class Planet_Imple : MonoBehaviour {

	[Range(200, 1000)]
	public int Mass_Modify = 200;

	[Range(0.2f, 10f)]
	public float ratio;

	public GameObject range;

	private Vector3 scale;
	private Rigidbody rb;
	private Color color_base_on_Mass;

	void Start(){
		rb = GetComponent<Rigidbody>();
		scale = new Vector3(1f, 1f, 0f);
		Mass_Modify = 200;
		color_base_on_Mass = new Color(1f, 1f, 1f, 1f);
		GetComponent<SpriteRenderer>().color = color_base_on_Mass;
	}

	void Update(){

		range.transform.localScale = new Vector3(scale.x * ratio, scale.y * ratio, 0f);
		rb.mass = Mass_Modify;
		color_base_on_Mass.b = 300f/(float) rb.mass;
		color_base_on_Mass.g = 300f/(float) rb.mass;
		//print(color_base_on_Mass.linear);
		GetComponent<SpriteRenderer>().color = color_base_on_Mass;
	}
}
