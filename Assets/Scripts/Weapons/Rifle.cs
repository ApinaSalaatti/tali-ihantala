using UnityEngine;
using System.Collections;

public class Rifle : Weapon {
	public float shootForce = 20f;

	public GameObject shellPrefab;
	public GameObject gunsmoke;
	public GameObject muzzleflash;
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

	protected override void Fire ()
	{
		StartCoroutine(MuzzleFlash());

		// Select correct prefab for bullet (special bullet if they are activated)
		GameObject prefab = usingSpecialAmmo ? specialBulletPrefab : bulletPrefab;

		GameObject b = (GameObject)Instantiate(prefab, transform.position + transform.forward, transform.rotation);
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

		Instantiate (gunsmoke,transform.position, transform.rotation);
		Instantiate (muzzleflash,transform.position, Quaternion.AngleAxis(Random.Range(0,360), Vector3.up));
	}

	private IEnumerator MuzzleFlash() {
		light.intensity = 1f;
		yield return new WaitForSeconds(0.1f);
		light.intensity = 0f;
	}
}
