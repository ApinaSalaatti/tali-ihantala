using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject followedObject;
	private CharacterController objectController;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - followedObject.transform.position;
		objectController = followedObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = followedObject.transform.position + offset;

		// Look at the front of the player so she can better see where she's going
		Vector3 targetSpeed = objectController.velocity;
		pos += targetSpeed / 3f;

		// The y position of the camera never changes NO MATTER WHAT!!
		pos.y = transform.position.y;

		transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 5f);
	}
}
