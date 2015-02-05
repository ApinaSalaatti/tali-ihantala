using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDamage(float damage) {
		Health h = GetComponent<Health>();

		float healthPrcnt = h.CurrentHealth / h.maxHealth;

		Color col = new Color(1f-healthPrcnt, healthPrcnt, 0.1f);
		renderer.material.color = col;
	}

	void OnDeath() {
		Destroy(gameObject);
	}
}
