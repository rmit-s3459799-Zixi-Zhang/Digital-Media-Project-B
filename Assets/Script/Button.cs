using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
	
	public void NewBtn(){

		SceneManager.LoadScene ("Sence1");
	}
	public void Exit(){
		Application.Quit ();
	}
}
