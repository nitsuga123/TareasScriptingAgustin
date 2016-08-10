using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public int ScoreValue;
	[SerializeField]
	private GameObject explosion;
	[SerializeField]
	private GameObject playerExp;

	private GameController gamecontroler;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gamecontroler = gameControllerObject.GetComponent<GameController> ();
		}

		if (gamecontroler == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExp, other.transform.position, other.transform.rotation);
			gamecontroler.GameOver ();
		}
		gamecontroler.AddScore (ScoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
