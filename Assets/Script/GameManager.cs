using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {
	public bool []levelClear;
	public Scene scene;
	public int a=20;
	public static GameManager instance;

	void Awake()
	{
		//Check if instance already exists
		if (instance == null) {
			//if not, set instance to this
			instance = this;
		}
		//If instance already exists and it's not this:
		else if (instance != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	

	void Start () {
		
		levelClear=new bool[a];
		for (int i = 0; i < levelClear.Length; i++) {
			levelClear [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		scene = SceneManager.GetActiveScene();

	}

	public static void Save() {
		//SaveLoad.savedGames.Add(Game.current);
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.dat"); //you can call it anything you want
		LevelData data= new LevelData();
		//data.levelClear [levelClear.Length] =GameManager.instance.levelClear[levelClear.Length];
		data.a=GameManager.instance.a;
		bf.Serialize(file,data);
		file.Close();
	}   
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.dat", FileMode.Open);
			LevelData data = (LevelData)bf.Deserialize(file);
			file.Close();
			//GameManager.instance.levelClear[levelClear.Length] = data.levelClear [levelClear.Length];
			GameManager.instance.a=data.a;
		}
	}

}
[System.Serializable]
class LevelData{
	public bool []levelClear;
	public int a;
}