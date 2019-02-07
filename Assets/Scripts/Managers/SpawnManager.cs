using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

	public GameObject enemyManager;
	public GameObject activateSpawn;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(){
		enemyManager.SetActive (true);
		Destroy (activateSpawn, 0.5f);
	}


}
