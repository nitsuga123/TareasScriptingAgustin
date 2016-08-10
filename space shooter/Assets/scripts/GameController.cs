using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private int score;

	private bool Gameover;
	private bool Restart;

	[SerializeField]
	private GameObject hazard;

	[SerializeField]
	private Vector3 spawnValues;

	[SerializeField]
	private GUIText scoreText;
	[SerializeField]
	private GUIText RestartText;
	[SerializeField]
	private GUIText GameOverText;





	void Start(){
		Gameover = false;
		Restart = false;
		RestartText.text = "";
		GameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}

	void Update(){
		if (Restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel); 
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(true){
		     for (int i=0;i<hazardCount;i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			 }
			yield return new WaitForSeconds (waveWait);

			if (Gameover) {
				RestartText.text ="Press 'R' for Resart";
				Restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){
		GameOverText.text="Game Over!";
		Gameover = true;
	}
}
