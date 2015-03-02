using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public static GameObject controlledObject;
	public float gravity;

	private static GameObject hijacker;
	public static void HijackInput(GameObject h) {
		if(hijacker == null) {
			hijacker = h;

			// Prevent trigger from staying down after input has been hijacked
			controlledObject.SendMessage("ReleaseTrigger");

			// Prevent movement from "getting stuck" on input hijack
			controlledObject.SendMessage("SetMovement", Vector3.zero);
		}
	}
	public static void ReleaseInput(GameObject h) {
		if(hijacker == h)
			hijacker = null;
	}

	void Start () {
		// The controlled object doesn't HAVE to be the same that this script is attached to.
		controlledObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(hijacker != null) {
			return;
		}

		if(Input.GetAxisRaw("Change Weapon") != 0) {
			controlledObject.SendMessage("ChangeWeapon");
		}

		if(Input.GetButtonDown("Interact")) {
			controlledObject.SendMessage("Interact");
		}
		
		if(Input.GetButtonDown("Fire1")) {
			controlledObject.SendMessage("PullTrigger");
		}
		if(Input.GetButtonUp("Fire1")) {
			controlledObject.SendMessage("ReleaseTrigger");
		}

		Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), gravity, Input.GetAxisRaw("Vertical"));
		controlledObject.SendMessage("SetMovement", movement);
	}
}
