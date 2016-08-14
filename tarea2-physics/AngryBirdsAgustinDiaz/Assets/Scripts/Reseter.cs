using UnityEngine;
using System.Collections;

public class Reseter : MonoBehaviour {

	public float resetSpeed=0.025f;
	private float resetSpeedSqr;

	[SerializeField]
	private Rigidbody2D projectile;

	private SpringJoint2D spring;

	void Start () {
		resetSpeedSqr = resetSpeed * resetSpeed;
		spring = projectile.GetComponent<SpringJoint2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Reset ();
		}

		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr) {
			Reset ();
		}
	}

	void Reset(){
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.GetComponent<Rigidbody2D>() == projectile) {
			Reset ();
		}

	}
}
