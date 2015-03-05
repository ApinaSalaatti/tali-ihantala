using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float damage;
	public GameObject smoke;
	public GameObject flash;
	//public GameObject bloodspill;
	//public GameObject bloodcloud;

	// Use this for initialization
	void Start () {
	
	}

	void Update() {

	}

	void OnCollisionEnter(Collision col) {
		GameObject go = col.collider.gameObject;

		//Vector3 pos = col.contacts[0].point;
		//Vector3 normal = col.contacts[0].normal;

		/*

		if(col.collider.gameObject.tag == "Humanoid") {
			Instantiate (bloodcloud, pos, transform.rotation);
			Instantiate (bloodspill, pos, transform.rotation);
		}
		else {
			Instantiate (smoke, pos, transform.rotation);
			Instantiate (flash, pos, transform.rotation);
		}*/

		int dl = LayerMask.NameToLayer("Destroyable");
		int el = LayerMask.NameToLayer("Enemy");
		int pl = LayerMask.NameToLayer("Player");

		if(go.layer == dl || go.layer == el || go.layer == pl) {
			DamageInfo d = new DamageInfo();
			d.damageAmount = damage;
			d.damageDirection = transform.forward;
			d.damageAt = col.contacts[0].point;
			d.damageNormal = col.contacts[0].normal;
			d.damageType = DamageType.PROJECTILE;

			go.SendMessage("TakeDamage", d, SendMessageOptions.DontRequireReceiver);
		}
		else { // If hit object is not destructible, player, or enemy, just spawn the basic particles
			Vector3 pos = col.contacts[0].point;
			Instantiate (smoke, pos, Quaternion.LookRotation(-transform.forward));
			Instantiate (flash, pos, Quaternion.LookRotation(-transform.forward));
		}

		BulletEffect[] effects = GetComponents<BulletEffect>();
		foreach(BulletEffect e in effects) {
			e.Affect(go);
		}
		
		Destroy(gameObject);
	}
}
