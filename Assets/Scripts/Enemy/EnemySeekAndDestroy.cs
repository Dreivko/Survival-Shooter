using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeekAndDestroy : MonoBehaviour {

	[Header ("Stats")]
	public float speed;
	public float stoppingDistance;
	public float nearDistance;
	public float startTimeBtwShoots;
	private float timeBtwShoots;

	[Header ("References")]

	public GameObject shot;
	//private Transform player;

	void Start () {
		//player = GameObject.FindGameObjectWithTag ("player").transform;	
	}

	void Update () {




	}
}
