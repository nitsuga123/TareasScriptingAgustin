using UnityEngine;
using System.Collections;

public class randomRotator : MonoBehaviour {

	public float tumble;

	[SerializeField]
	private Rigidbody rigidbody;

	void Start(){
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
