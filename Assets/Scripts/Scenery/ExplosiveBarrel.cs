using UnityEngine;
using System.Collections;

public class ExplosiveBarrel : MonoBehaviour {
	public float blastRadius = 5f;
	public float damage = 5f;

	private bool alreadyExploded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDeath() {
		if(alreadyExploded) {
			return;
		}
		alreadyExploded = true;

		// EXPLODE!! (i.e. find all gameobjects that are in the blast radius and HURT them)
		int layerMask = LayerMask.GetMask("Destroyable", "Enemy", "Player");

		DamageInfo info = new DamageInfo();
		info.damageAmount = damage;
		info.damageType = DamageType.EXPLOSION;

		Collider[] cols = Physics.OverlapSphere(transform.position, blastRadius, layerMask);
		foreach(Collider col in cols) {
			// Blow everything but yourself
			if(col.gameObject != gameObject) {
				info.damageAt = col.gameObject.transform.position;
				info.damageDirection = col.gameObject.transform.position - transform.position;
				col.gameObject.SendMessage("TakeDamage", info);
			}
		}
		
		Destroy(gameObject);
	}
}
