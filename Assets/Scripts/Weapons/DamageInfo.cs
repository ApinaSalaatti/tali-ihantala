using UnityEngine;
using System.Collections;

public enum DamageType { PROJECTILE, EXPLOSION, FIRE, POISON };

public class DamageInfo {
	public DamageType damageType;
	public Vector3 damageAt;
	public Vector3 damageDirection;
	public Vector3 damageNormal; // Direction of the normal vector at damage position
	public float damageAmount;
}
