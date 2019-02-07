using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score;
	public GameObject nextLvl;
	public GameObject powerUp;
	public PlayerShooting dmg;
	public int neededScore;

    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;

		if (score > 300 && dmg.damagePerShot < 21 ) {
			powerUp.SetActive (true);
		}

		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			if (score >= neededScore) {
				text.text = "You Win !";
				CancelInvoke ("Spawn");
				Destroy (GameObject.Find ("Hellephant(Clone)"));
				Destroy (GameObject.Find ("ZomBear(Clone)"));
				Destroy (GameObject.Find ("Zombunny(Clone)"));
				Destroy (GameObject.Find ("ZombunnyPatrol"));
				Destroy (GameObject.Find ("ZomBearPatrol"));
				nextLvl.SetActive (true);
			}
		}
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			if (score >= neededScore) {
				text.text = "End Of Game !";
				CancelInvoke ("Spawn");
				Destroy (GameObject.Find ("Hellephant(Clone)"));
				Destroy (GameObject.Find ("ZomBear(Clone)"));
				Destroy (GameObject.Find ("Zombunny(Clone)"));
				Destroy (GameObject.Find ("ZombunnyPatrol"));
				Destroy (GameObject.Find ("ZomBearPatrol"));
			}
		}

    }
}
