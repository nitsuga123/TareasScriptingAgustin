using UnityEngine;
using System.Collections;

public class ScreenBlack : MonoBehaviour {

	void Awake(){
		
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.tag == "Damager") {


		}
	}
}
