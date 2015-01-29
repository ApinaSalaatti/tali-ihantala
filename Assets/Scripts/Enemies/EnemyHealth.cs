using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float maxHealth = 10;

	private float health;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TakeDamage(float damage) {
		health -= damage;

		float healthPrcnt = health / maxHealth;

		Color col = new Color(1f-healthPrcnt, healthPrcnt, 0.1f);
		renderer.material.color = col;

		if(health <= 0f) {
			Destroy(gameObject);
		}
	}
}
