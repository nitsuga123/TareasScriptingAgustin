using UnityEngine;
using System.Collections;

public class mouselook : MonoBehaviour {

	Vector2 MouseLook;//how much movement the camera has made
	Vector2 smoothv;//smooths movement of the mass
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject character;
	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject; //sets the camera parent, the player
	}
	
	// Update is called once per frame
	void Update () {
		// we get he change in the mouse
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		//luego multiplicamos por la sensitividad
		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		//lerp helps to smooth movement so item just dont snap
		smoothv.x = Mathf.Lerp (smoothv.x, md.x, 1f / smoothing);
		smoothv.y = Mathf.Lerp (smoothv.y, md.y, 1f / smoothing);
		MouseLook += smoothv;
		MouseLook.y = Mathf.Clamp (MouseLook.y, -90f, 90f);

		//firstone rotates the camera on th y axis
		transform.localRotation = Quaternion.AngleAxis (-MouseLook.y, Vector3.right);
		//second one rotates the character, not the camera;
		character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, character.transform.up);



	}
}
