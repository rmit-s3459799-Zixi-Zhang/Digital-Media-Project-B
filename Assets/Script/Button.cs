using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
	
	public GameObject PauseMenu;


	public void Menu(){
		SceneManager.LoadScene ("Menu");
		Time.timeScale = 1;
	}
	public void Exit(){
		
		Application.Quit ();
	}
	public void Reload(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
		Time.timeScale = 1;
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
	public void LoadLevels(){
		SceneManager.LoadScene ("level");
		Time.timeScale = 1;
	}
	public void LoadLevel1(){
		SceneManager.LoadScene ("level1");
		Time.timeScale = 1;
	}
	public void LoadLevel2(){
		if(GameManager.instance.levelClear[1]==true){
			SceneManager.LoadScene ("level2");
			Time.timeScale = 1;
		}else{
			print ("level2 is locked");
		}
	}
	public void LoadLevel3(){
		if(GameManager.instance.levelClear[2]==true){
			SceneManager.LoadScene ("level3");
			Time.timeScale = 1;
		}else{
			print ("level3 is locked");
		}
	}
	public void LoadLevel4(){
		if(GameManager.instance.levelClear[3]==true){
			SceneManager.LoadScene ("level4");
			Time.timeScale = 1;
		}else{
			print ("level4 is locked");
		}
	}



}
