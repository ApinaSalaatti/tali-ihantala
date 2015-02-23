using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5f;

	private PlayerWeaponController weapons;
	private CharacterController controller;
	private Vector3 movement = new Vector3();

	// Use this for initialization
	void Start () {
		weapons = GetComponent<PlayerWeaponController>();
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.y));
		//mousePos.y = transform.position.y;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, 100f)) {
			Vector3 mousePos = hit.point;
			Vector3 offset = Vector3.zero;

			weapons.AimAt(mousePos);

			mousePos.y = transform.position.y;
			transform.LookAt(mousePos);
		}

		// Enable this line if you want moving "forward" to move towards the mouse
		//movement = transform.TransformDirection(movement);

		controller.Move(movement * speed * Time.deltaTime);
	}

	void SetMovement(Vector3 m) {
		movement = m;
	}
}
