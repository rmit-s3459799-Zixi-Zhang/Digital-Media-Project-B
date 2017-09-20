using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour {

	public bool change_Color_Trigger = false;

	private SpriteRenderer spRend;

	//Range between alpha 80 to 210
	private float Transparency_min = 0.315f;

	private float Transparency_max = 0.823f;

	private bool Increase_alpha = false;
	private bool decrease_alpha = false;

	private Color tmp_color;

	void Start () {
		spRend = GetComponent<SpriteRenderer>();
		tmp_color = spRend.color;
		Increase_alpha = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Increase_alpha){
			tmp_color.a += Time.fixedDeltaTime;
		}

		if (tmp_color.a >= Transparency_max){
			Increase_alpha = false;
			decrease_alpha = true;
		}

		if(decrease_alpha){
			tmp_color.a -= Time.fixedDeltaTime;
		}

		if (tmp_color.a <= Transparency_min){
			Increase_alpha = true;
			decrease_alpha = false;
		}

		spRend.color = tmp_color;

		//print("Alpha val : " + spRend.color.a);
	}
}
