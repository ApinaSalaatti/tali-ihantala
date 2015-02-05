using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float damage;

	// Use this for initialization
	void Start () {
	
	}

	void Update() {

	}

	private void HitObject(GameObject go) {
		go.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col) {
		HitObject(col.collider.gameObject);
	}
}
