using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject bloodCloud;
	public GameObject bloodSpill;

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDamage(DamageInfo info) {
		Health h = GetComponent<Health>();

		float healthPrcnt = h.CurrentHealth / h.maxHealth;

		Color col = new Color(1f-healthPrcnt, healthPrcnt, 0.1f);
		renderer.material.color = col;

		Instantiate(bloodCloud, info.damageAt, Quaternion.LookRotation(info.damageDirection));
		Instantiate(bloodSpill, info.damageAt, Quaternion.LookRotation(info.damageDirection));
	}

	void OnDeath() {
		Destroy(gameObject);
	}
}
