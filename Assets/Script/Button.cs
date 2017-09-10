using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
	public GameObject PauseMenu;


	public void LoadLevels(){
		SceneManager.LoadScene ("Sence3");
	}
	public void Menu(){
		SceneManager.LoadScene ("Menu");
	}
	public void Exit(){
		Application.Quit ();
	}
	public void Reload(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
	public void Cancel(){
		PauseMenu.SetActive(false);
		Time.timeScale = 1;
	}
	public void Pause(){
		if (Time.timeScale == 1) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		}

	}
}
