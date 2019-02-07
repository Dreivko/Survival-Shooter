using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

	public float delay = 3f;

	float countdown;
	bool hasExploded = false;
	public float radius = 15f;
	public float force = 500f;
	AudioSource granadeClip;

	public GameObject explosionParticles;


	// Use this for initialization
	void Start () {
		countdown = delay;
		granadeClip = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0 && !hasExploded) {
			
			Explode ();
			hasExploded = true;
		}
	}

	void Explode(){
		granadeClip.Play();

		Instantiate (explosionParticles, transform.position, transform.rotation);
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius); 
		foreach (Collider nearbyObject in colliders) {
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				rb.AddExplosionForce (force, transform.position, radius);
			}
		}


		Destroy (gameObject);
	}

}
