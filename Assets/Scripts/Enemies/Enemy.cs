using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject bloodCloud;
	public GameObject bloodSpill;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDamage(DamageInfo info) {
		Health h = GetComponent<Health>();

		float healthPrcnt = h.CurrentHealth / h.maxHealth;

		Color col = new Color(1f-healthPrcnt, healthPrcnt, 0.1f);
		GetComponent<Renderer>().material.color = col;

		Quaternion rot = info.damageDirection == Vector3.zero ? Quaternion.identity : Quaternion.LookRotation(info.damageDirection);

		Instantiate(bloodCloud, info.damageAt, rot);
		Instantiate(bloodSpill, info.damageAt, rot);
	}

	void OnDeath() {
		Destroy(gameObject);
	}
}
