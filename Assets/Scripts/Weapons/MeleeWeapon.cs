using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour {
	public float damage = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	void OnCollisionEnter(Collision col) {
		Debug.Log(col.gameObject.name);
		GameObject go = col.collider.gameObject;

		DamageInfo d = new DamageInfo();
		d.damageAmount = damage;
		d.damageDirection = transform.forward;
		d.damageAt = col.contacts[0].point;
		d.damageNormal = col.contacts[0].normal;
		d.damageType = DamageType.PROJECTILE;

		go.SendMessage("TakeDamage", d, SendMessageOptions.DontRequireReceiver);
	}
	*/

	void OnTriggerEnter(Collider c) {
		int l = LayerMask.NameToLayer("Player");
		if(c.gameObject.layer == l) { // Only hit the player because only enemies have melee weapons (may need to change this later)
			GameObject go = c.gameObject;
			
			DamageInfo d = new DamageInfo();
			d.damageAmount = damage;
			d.damageDirection = transform.forward;
			d.damageAt = go.transform.position;
			d.damageNormal = Vector3.zero;
			d.damageType = DamageType.PROJECTILE;
			
			go.SendMessage("TakeDamage", d, SendMessageOptions.DontRequireReceiver);
		}
	}
}
