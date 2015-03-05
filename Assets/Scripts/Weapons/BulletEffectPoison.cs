using UnityEngine;
using System.Collections;

public class BulletEffectPoison : BulletEffect {
	public float damagePerSec;
	public float length;

	public override void Affect (GameObject obj)
	{
		BuffManager bm = obj.GetComponent<BuffManager>();
		if(bm != null) {
			bm.AddBuff(
				new DamageOverTimeBuff("Poison", DamageType.POISON, damagePerSec, length)
			);
		}
	}

}
