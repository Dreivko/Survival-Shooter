using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

	public GameObject floatingTextPrefab;
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        
		hitParticles.Play();

		if (floatingTextPrefab  &&  currentHealth > 0 ) {
			ShosFloatingText ();
		}
			
        if(currentHealth <= 0)
        {
            Death ();
        }
    }

	void OnParticleCollision(){

		//Destroy (gameObject);
		currentHealth -= 50;

		if (floatingTextPrefab  &&  currentHealth > 0 ) {
			ShosFloatingText ();
		}

		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void ShosFloatingText (){

		var go = Instantiate (floatingTextPrefab, transform.position, Quaternion.identity, transform);
		go.GetComponent<TextMesh> ().text = currentHealth.ToString();
	}


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
