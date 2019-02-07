using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {

	public float destroyTime = 1f;
	public Vector3 offSet = new Vector3 (0,2,0);
	public Vector3 randomIntensity = new Vector3 (0.5f,0,0);

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
		transform.localPosition += offSet;

		Random.Range (-randomIntensity.y, randomIntensity.y);
		Random.Range (-randomIntensity.z, randomIntensity.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
