using UnityEngine;
using System.Collections;

public class charControler : MonoBehaviour {


	public float speed = 10f;
	public float ShotSpeed= 10f;

	[SerializeField]
	private GameObject bullet;

	[SerializeField]
	private Transform salidaBala;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
	
		float trans = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		trans *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (straffe, 0, trans);

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}


		if (Input.GetButtonDown("Fire1")) {
			GameObject bala;
			bala = Instantiate(bullet, salidaBala.position + salidaBala.forward *2f, salidaBala.rotation)as GameObject;;
			bala.GetComponent<Rigidbody> ().AddForce (bala.transform.forward * ShotSpeed);
		}
	}


}
