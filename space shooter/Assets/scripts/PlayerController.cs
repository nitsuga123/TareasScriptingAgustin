using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public float fireRate;

	public Boundary boundary;
	[SerializeField]
	private Rigidbody rigidbody;
	[SerializeField]
	private GameObject Shot;
	[SerializeField]
	private Transform shotSpawn;
	[SerializeField]
	private AudioSource audio;

	private float nextFire;

	void Awake(){
		audio = GetComponent<AudioSource>();
	}

	void Update(){

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(Shot,shotSpawn.position,shotSpawn.rotation);
			audio.Play ();

		}
	}
	void FixedUpdate()
	{
		float MoveH = Input.GetAxis ("Horizontal");
		float Movev = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (MoveH, 0.0f, Movev);
		rigidbody.velocity = movement * speed;
		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x,boundary.xMin,boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rigidbody.position.z,boundary.zMin,boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler(0.0f,0.0f,rigidbody.velocity.x * -tilt);
	}

}
