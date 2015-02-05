using UnityEngine;
using System.Collections;

public class GrenadeLauncher : Weapon {
	public GameObject grenadePrefab;
	public float launchForce = 5f;

	protected override void Fire ()
	{
		GameObject g = (GameObject)Instantiate(grenadePrefab, transform.position + transform.forward, Quaternion.identity);
		Vector3 launchDir = transform.forward;
		launchDir.y += 0.3f; // Launch the grenade a bit upwards
		launchDir = launchDir.normalized;
		g.rigidbody.AddForce(launchDir * launchForce, ForceMode.Impulse);
	}
}
