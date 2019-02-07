using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement2 : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

	//Transform patrolPoint1;
	//Transform patrolPoint2;

	public GameObject patrolPoint1;
	public GameObject patrolPoint2;
	GameObject objective;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
		objective = patrolPoint1;
		StartCoroutine(StartPatrol());
    }


    void Update (){
		if (Vector3.Distance (transform.position, player.position) < 6) {
			if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
				StopCoroutine (StartPatrol());
				nav.SetDestination (player.position);
			} else {
				StopCoroutine (StartPatrol());
				nav.enabled = false;
			}
		} 
			
    }

	IEnumerator StartPatrol(){
		// TODO: Fix Error when enemy health is 0 

		while (true) {
			if (nav.enabled == true) {
				nav.SetDestination (objective.transform.position);
			}

			yield return new WaitForSecondsRealtime (3f);
			if (objective.Equals (patrolPoint2)) {
				//Debug.Log (objective);
				objective = patrolPoint1;
			} else {
				//Debug.Log (objective);
				objective = patrolPoint2;
			}
			if (nav.enabled == true) {
				nav.SetDestination (objective.transform.position);
			}

		}
	}



}
