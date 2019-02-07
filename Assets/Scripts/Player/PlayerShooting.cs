using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
	public GameObject GunBarrelEnd;

	// Granade

	public float throwForce = 5f;
	public GameObject granadePrefab;
	public int granadeQuantity = 10;
	public float timeBetweenGranades = 15f;
	bool hasExploded = false;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
		/*
		gunParticles = GetComponentInChildren <ParticleSystem> ();
		gunLine = GetComponentInChildren <LineRenderer> ();
		gunAudio = GetComponentInChildren <AudioSource> ();
		gunLight = GetComponentInChildren <Light> ();*/

		gunParticles = GunBarrelEnd.GetComponent<ParticleSystem> ();
        gunLine = GunBarrelEnd.GetComponent <LineRenderer> ();
		gunAudio = GunBarrelEnd.GetComponent<AudioSource> ();
		gunLight = GunBarrelEnd.GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

		if (Input.GetButton ("Fire2") && granadeQuantity > 0 && timer >= timeBetweenGranades && Time.timeScale !=0) {
			ThrowGranade ();
		}

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)){

			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

			Resistance resistance = shootHit.collider.GetComponent<Resistance> ();

			//Debug.Log (shootHit.collider.gameObject);

			if (resistance != null) {
				resistance.shooted (shootHit.point);
			}

            if(enemyHealth != null){
				
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
				


            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

	void ThrowGranade (){
		GameObject granade = Instantiate (granadePrefab, transform.position, transform.rotation);
		granade.transform.position = new Vector3 (transform.position.x,0.5f,transform.position.z);
		Rigidbody rb = granade.GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * throwForce, ForceMode.VelocityChange);


		granadeQuantity--;

	}

}
