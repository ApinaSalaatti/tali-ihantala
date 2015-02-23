using UnityEngine;
using System.Collections;

public class GameScreen : MonoBehaviour {

	public void Open() {
		InputManager.HijackInput(gameObject);
		
		transform.localScale = new Vector3(1f, 1f, 1f);
	}
	
	public void Close() {
		InputManager.ReleaseInput(gameObject);
		
		transform.localScale = new Vector3(0f, 0f, 0f);
	}
}
