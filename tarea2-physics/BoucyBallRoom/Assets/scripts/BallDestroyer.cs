using UnityEngine;
using System.Collections;

public class BallDestroyer : MonoBehaviour {

	public bool DestruirBolas;
	public float resetSpeed=0.025f;
	private float resetSpeedSqr;
	// Use this for initialization
	void Start () {
		resetSpeedSqr = resetSpeed * resetSpeed;
	}

	// Update is called once per frame
	void Update () {
		if (DestruirBolas == true) {
			if (gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude < resetSpeedSqr) {
				Destroy (this.gameObject);
			}
		}


	}


	void OnTriggerExit(){
		Destroy (this.gameObject);
	}
}




