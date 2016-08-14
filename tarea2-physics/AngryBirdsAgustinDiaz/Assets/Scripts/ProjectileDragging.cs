using UnityEngine;
using System.Collections;

public class ProjectileDragging : MonoBehaviour {

	public float maxStretch = 3f;
	public Rigidbody2D rb2d;
	[SerializeField]
	private LineRenderer catapultLineFront;

	[SerializeField]
	private LineRenderer catapultLineBack;



	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray LeftCatapultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	private bool clickedOn;
	private Vector2 prevVelocity;



	void Awake(){
		spring = GetComponent<SpringJoint2D> ();
		catapult = spring.connectedBody.transform;
	}
	void Start () {
		LineRenderSetup ();
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		LeftCatapultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		rb2d = GetComponent<Rigidbody2D> ();
		CircleCollider2D circle = GetComponent<CircleCollider2D> ();
		circleRadius = circle.radius;

	}


	void Update () {
		if (clickedOn)
			Dragging ();

		if (spring != null) {
			if (!rb2d.isKinematic && prevVelocity.sqrMagnitude > rb2d.velocity.sqrMagnitude) {
				Destroy (spring);
				rb2d.velocity = prevVelocity;
			}
			if (!clickedOn) 
				prevVelocity = rb2d.velocity;

			LineRendererUpdate ();
		} else {
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}
	}

	void LineRenderSetup(){
		catapultLineFront.SetPosition (0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition (0, catapultLineBack.transform.position);

		catapultLineFront.sortingLayerName= "Foreground";
		catapultLineBack.sortingLayerName= "Foreground";

		catapultLineFront.sortingOrder = 1;
		catapultLineBack.sortingOrder = 3;
	}

	void OnMouseDown(){
		spring.enabled = false;
		clickedOn = true;
	}

	void OnMouseUp(){
		spring.enabled = true;
		rb2d.isKinematic = false;
		clickedOn = false;
	}

	void Dragging(){

		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;

		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (maxStretch);
		}
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	
	}

	void LineRendererUpdate(){
		Vector2 catapultToProyectile = transform.position - catapultLineFront.transform.position;
		LeftCatapultToProjectile.direction = catapultToProyectile;
		Vector3 holdPoint = LeftCatapultToProjectile.GetPoint (catapultToProyectile.magnitude + circleRadius);
		catapultLineFront.SetPosition (1, holdPoint);
		catapultLineBack.SetPosition (1, holdPoint);
	}

}
