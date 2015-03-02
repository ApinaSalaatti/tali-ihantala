using UnityEngine;
using System.Collections;

public class BulletEffectExplosion : BulletEffect {
	public float blastRadius = 2f;
	public float damage = 1f;

	public override void Affect (GameObject obj) {
		int layerMask = LayerMask.GetMask("Destroyable", "Enemy");
		Collider[] cols = Physics.OverlapSphere(transform.position, blastRadius, layerMask);
		foreach(Collider col in cols) {
			if(col.gameObject != gameObject)
				col.gameObject.SendMessage("TakeDamage", damage);
		}
	}
}
