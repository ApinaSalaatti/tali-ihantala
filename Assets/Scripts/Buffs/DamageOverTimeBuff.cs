using UnityEngine;
using System.Collections;

public class DamageOverTimeBuff : Buff {
	public DamageType DType {
		get; set;
	}
	public float AmountPerSecond {
		get; set;
	}

	private float timer;

	public DamageOverTimeBuff(string name, DamageType type, float amountPerSecond, float length) : base(name, length) {
		DType = type;
		AmountPerSecond = amountPerSecond;
	}

	public override void BuffUpdate() {
		timer += Time.deltaTime;
		// Apply damage once per second
		if(timer >= 1f) {
			timer = 0f;
			DamageInfo info = new DamageInfo();
			info.damageType = DType;
			info.damageAt = affectedObject.transform.position;
			info.damageDirection = Vector3.zero;
			info.damageAmount = AmountPerSecond;
			affectedObject.SendMessage("TakeDamage", info, SendMessageOptions.DontRequireReceiver);
		}
	}
}
