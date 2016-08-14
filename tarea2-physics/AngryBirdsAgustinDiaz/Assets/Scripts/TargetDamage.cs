using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {

	public int hitpoints = 2;
	public Sprite damagedSprite;
	public float damageImpactSpeed;

	private int currentHitPoints;
	private float damageImpactSpeedSqr;
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Collider2D col2d;
	[SerializeField]
	private Rigidbody2D rig2d;
	[SerializeField]
	private ParticleSystem partsis;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		currentHitPoints = hitpoints;
		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
		col2d = GetComponent<Collider2D>();
		rig2d = GetComponent<Rigidbody2D> ();
		partsis = GetComponent<ParticleSystem> ();
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.tag != "Damager") 
			return;
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
			return;

		spriteRenderer.sprite = damagedSprite;
		currentHitPoints--;

		if (currentHitPoints <= 0)
			kill ();
	}

	void kill(){
		spriteRenderer.enabled = false;
		col2d.enabled = false;
		rig2d.isKinematic = true;
		partsis.Play ();
	}
}
