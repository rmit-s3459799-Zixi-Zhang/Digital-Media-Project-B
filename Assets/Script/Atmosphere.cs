using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour {
	public GameObject Tartget;
	public float Transparency;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer spRend = Tartget.transform.GetComponent<SpriteRenderer>();
		// copy the SpriteRenderer's color property
		Color col = spRend.color;
		//  change col's alpha value (0 = invisible, 1 = fully opaque)
		col.a = Transparency; // 0.5f = half transparent
		// change the SpriteRenderer's color property to match the copy with the altered alpha value
		spRend.color = col;
	}
}
