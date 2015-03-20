using UnityEngine;
using System.Collections;

public abstract class BulletEffect : MonoBehaviour {
	public DamageType damageType;
	public abstract void Affect(GameObject obj);
}
