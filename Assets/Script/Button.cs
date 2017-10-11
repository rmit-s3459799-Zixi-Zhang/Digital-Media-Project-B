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
	public void LoadLevel5(){
		if(GameManager.instance.levelClear[4]==true){
			SceneManager.LoadScene ("level5");
			Time.timeScale = 1;
		}else{
			print ("level5 is locked");
		}
	}
	public void LoadLevel6(){
		if(GameManager.instance.levelClear[5]==true){
			SceneManager.LoadScene ("level6");
			Time.timeScale = 1;
		}else{
			print ("level6 is locked");
		}
	}
	public void LoadLevel7(){
		if(GameManager.instance.levelClear[6]==true){
			SceneManager.LoadScene ("level7");
			Time.timeScale = 1;
		}else{
			print ("level7 is locked");
		}
	}
	public void LoadLevel8(){
		if(GameManager.instance.levelClear[7]==true){
			SceneManager.LoadScene ("level8");
			Time.timeScale = 1;
		}else{
			print ("level8 is locked");
		}
	}
	public void LoadLevel9(){
		if(GameManager.instance.levelClear[8]==true){
			SceneManager.LoadScene ("level9");
			Time.timeScale = 1;
		}else{
			print ("level9 is locked");
		}
	}
	public void LoadLevel10(){
		if(GameManager.instance.levelClear[9]==true){
			SceneManager.LoadScene ("level10");
			Time.timeScale = 1;
		}else{
			print ("level10 is locked");
		}
	}
	public void LoadLevel11(){
		if(GameManager.instance.levelClear[10]==true){
			SceneManager.LoadScene ("level11");
			Time.timeScale = 1;
		}else{
			print ("level11 is locked");
		}
	}
	public void LoadLevel12(){
		if(GameManager.instance.levelClear[11]==true){
			SceneManager.LoadScene ("level12");
			Time.timeScale = 1;
		}else{
			print ("level12 is locked");
		}
	}
	public void UnLock(){

		for (int i = 0; i < GameManager.instance.levelClear.Length; i++) {
			GameManager.instance.levelClear [i] = true;
		}

	}

}