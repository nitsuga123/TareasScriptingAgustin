using UnityEngine;
using System.Collections;

public class ProyectileFollow : MonoBehaviour {


	[SerializeField]
	private Transform projectile;
	[SerializeField]
	private Transform farLeft;
	[SerializeField]
	private Transform farRight;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = projectile.position.x;
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		transform.position = newPosition; 
	
	}
}
