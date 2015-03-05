using UnityEngine;
using System.Collections;

public class LookatCamera : MonoBehaviour {
	
	void Update () {
		transform.LookAt(Camera.main.transform.position);
	}
}
