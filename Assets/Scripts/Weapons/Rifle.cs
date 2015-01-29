using UnityEngine;
using System.Collections;

public class Rifle : Weapon {
	public float shootForce = 20f;

	public GameObject bulletPrefab;
	//private LineRenderer fireLine;
	
	// Use this for initialization
	void Start () {
		//fireLine = GetComponent<LineRenderer>();
	}

	/*
	protected override void Fire() {
		StartCoroutine(MuzzleFlash());
		
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, range)) {
			hit.collider.gameObject.SendMessage("TakeDamage", damage);
			StartCoroutine(FireLine(transform.position, hit.collider.gameObject.transform.position));
		}
		else {
			StartCoroutine(FireLine(transform.position, transform.position + transform.forward * range));
		}
	}

	private IEnumerator FireLine(Vector3 start, Vector3 end) {
		fireLine.enabled = true;
		fireLine.SetPosition(0, start);
		fireLine.SetPosition(1, end);
		yield return new WaitForSeconds(0.1f);
		fireLine.enabled = false;
	}
	*/

	protected override void Fire ()
	{
		StartCoroutine(MuzzleFlash());
		GameObject b = (GameObject)Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
		b.rigidbody.AddForce(transform.forward * shootForce, ForceMode.Impulse);
	}

	private IEnumerator MuzzleFlash() {
		light.intensity = 1f;
		yield return new WaitForSeconds(0.1f);
		light.intensity = 0f;
	}
}
