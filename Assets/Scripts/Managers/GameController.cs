using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController control; 
	public GameObject player;

	void awake(){
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/gamedata.dat");

		GameData data = new GameData ();
		data.posx = player.transform.position.x;
		data.posy = player.transform.position.y;
		data.posz = player.transform.position.z;
		data.currentHealth = player.GetComponent<PlayerHealth> ().currentHealth;
		data.score = GameObject.Find ("ScoreText").ToString();



		bf.Serialize (file, data);
		file.Close ();

	}

	public void Load(){
		if (File.Exists(Application.persistentDataPath + "/gamedata.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/gamedata.dat", FileMode.Open);

			GameData data = (GameData) bf.Deserialize (file);
			file.Close ();

			GameObject player = GameObject.Find ("Player");

			Vector3 position = new Vector3 (data.posx, data.posy, data.posz);
			player.transform.position = position;
			player.GetComponent<PlayerHealth> ().currentHealth = data.currentHealth;
			GameObject scoreTxt = GameObject.Find ("ScoreText");
			//scoreTxt = data.score;
			 
		}
	}

	/*
	public void LoadScene(){
		SceneManager.LoadScene (1);
	}*/


}


[Serializable]
class GameData {
	public float posx;
	public float posy;
	public float posz;
	public string score;
	public int currentHealth;
	public GameObject [] crates;



}