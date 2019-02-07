using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResistance : MonoBehaviour {
	
	public int startingHealth = 60;
	public int currentHealth;
	public int scoreValue = 5;
	public AudioClip destroyClip;


	AudioSource objectAudio;
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;


	void Awake (){
		objectAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();

		currentHealth = startingHealth;
	}


	void Update (){

	}


	public void TakeDamage (int amount, Vector3 hitPoint){

		objectAudio.Play ();

		currentHealth -= amount;

		hitParticles.transform.position = hitPoint;
		hitParticles.Play();

		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void OnParticleCollision(){
		currentHealth -= 5;

		if(currentHealth <= 0){
			Death ();
		}
	}


	void Death (){

		capsuleCollider.isTrigger = true;

		objectAudio.clip = destroyClip;
		objectAudio.Play ();

		//Destroy (transform, 1f);
	}


}
