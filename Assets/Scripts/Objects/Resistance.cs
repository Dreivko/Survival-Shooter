using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour {


	public int resistance;
	public int scoreValue = 5;

	AudioSource objectAudio;
	ParticleSystem hitParticles;


	public Rigidbody rb;

	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		//Audio
		objectAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();

		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		ps = GetComponentInChildren<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void shooted(Vector3 ImpactDot){

		objectAudio.Play ();

		hitParticles.transform.position = ImpactDot;
		hitParticles.Play();

		resistance--;

		if (resistance <= 0) {
			Destroy (transform.gameObject);
			ScoreManager.score += scoreValue;
		}

	}



	void OnParticleCollision(){
		
	}

	public IEnumerator WaitToAction(){
		yield return new WaitForSecondsRealtime (2);
	}


}
