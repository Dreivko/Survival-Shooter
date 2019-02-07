using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	public PlayerShooting dmg;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			dmg.damagePerShot = 50;
			gameObject.SetActive (false);			
		}

	}

}
