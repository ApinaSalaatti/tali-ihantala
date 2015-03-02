using UnityEngine;
using System.Collections;

public class BulletEffectPoison : BulletEffect {
	public float damagePerSec;
	public float length;

	private GameObject toAffect;

	public override void Affect (GameObject obj)
	{
		toAffect = obj;
		StartCoroutine(StartAffecting());
	}

	private IEnumerator StartAffecting() {
		Debug.Log("Poison starting to take effect!");
		InvokeRepeating("EffectIteration", 1f, 1f);

		yield return new WaitForSeconds(length);

		Debug.Log("Poison effect ends");
		CancelInvoke("EffectIteration");
	}

	private void EffectIteration() {
		Debug.Log("Poison damaging something!");
		toAffect.SendMessage("TakeDamage", damagePerSec, SendMessageOptions.DontRequireReceiver);
	}
}
