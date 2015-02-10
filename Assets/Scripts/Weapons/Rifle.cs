using UnityEngine;
using System.Collections;

public class Rifle : Weapon {
	public float shootForce = 20f;

	public GameObject bulletPrefab;
	public GameObject shellPrefab;
	public float inaccuracy;
	public float shellminimumforce;
	public float shellmaximumforce;

	// Use this for initialization
	void Start () {
	}

	private float burstTimer = 0f;

	protected override void WeaponUpdate ()
	{
		if(firing) {
			burstTimer += 0.5f * Time.deltaTime;
			if(burstTimer > 1f) burstTimer = 1f;
		}
		else {
			burstTimer -= Time.deltaTime;
			if(burstTimer < 0f)
				burstTimer = 0f;
		}
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
		Vector3 shootDir = Vector3.forward;
		// Add some inaccuracy 'cause it looks cool!
		float inacc = Random.Range(-inaccuracy, inaccuracy) * burstTimer; // The inaccuracy increases the longer you fire
		shootDir.x += inacc;
		shootDir = transform.TransformDirection(shootDir.normalized);
		b.rigidbody.AddForce(shootDir * shootForce, ForceMode.Impulse);


		GameObject s = Instantiate (shellPrefab,transform.position, transform.rotation) as GameObject;
		Rigidbody shell = s.GetComponent<Rigidbody>();
		shell.AddForce (transform.TransformDirection(Vector3.right*Random.Range (shellminimumforce, shellmaximumforce)), ForceMode.Impulse);
		shell.AddTorque (Vector3.up*Random.Range (10f, 100f));
		shell.AddTorque (Vector3.forward*Random.Range(10f, 100f));
	}

	private IEnumerator MuzzleFlash() {
		light.intensity = 1f;
		yield return new WaitForSeconds(0.1f);
		light.intensity = 0f;
	}
}
