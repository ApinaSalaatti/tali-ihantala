using UnityEngine;
using System.Collections;

public class BulletEffectExplosion : BulletEffect {
	public float blastRadius = 2f;
	public float damage = 1f;

	void Start() {
		this.damageType = DamageType.FIRE;
	}

	public override void Affect (GameObject obj) {
		int layerMask = LayerMask.GetMask("Destroyable", "Enemy", "Scenery");
		Collider[] cols = Physics.OverlapSphere(transform.position, blastRadius, layerMask);
		foreach(Collider col in cols) {
			if(col.gameObject != gameObject) {
				DamageInfo info = new DamageInfo();
				info.damageAmount = damage;
				info.damageAt = col.gameObject.transform.position;
				info.damageDirection = col.gameObject.transform.position - transform.position;
				info.damageNormal = Vector3.zero;
				info.damageType = damageType;
				col.gameObject.SendMessage("TakeDamage", info);
			}
		}
	}
}
