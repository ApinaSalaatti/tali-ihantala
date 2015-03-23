using UnityEngine;
using System.Collections;

public class ExplosiveBarrel : MonoBehaviour {
	public float blastRadius = 5f;
	public float damage = 5f;

	private bool alreadyExploded = false;
	public GameObject explosion;


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
		int layerMask = LayerMask.GetMask("Destroyable", "Enemy", "Player", "Scenery");

		DamageInfo info = new DamageInfo();
		info.damageAmount = damage;
		info.damageType = DamageType.EXPLOSION;

		Collider[] cols = Physics.OverlapSphere(transform.position, blastRadius, layerMask);
		Debug.Log ("explosioncheck");
		foreach(Collider col in cols) {
			Debug.Log(col.gameObject.name);
			// Blow everything but yourself
			if(col.gameObject != gameObject) {
				info.damageAt = col.gameObject.transform.position;
				info.damageDirection = (col.gameObject.transform.position - transform.position).normalized;
				col.gameObject.SendMessage("TakeDamage", info, SendMessageOptions.DontRequireReceiver);
			}
		}
		Instantiate (explosion, transform.position, explosion.transform.rotation);
		Destroy(gameObject);
	}
}
