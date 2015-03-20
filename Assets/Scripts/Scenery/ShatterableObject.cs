using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class ShatterableObject : MonoBehaviour {
	public GameObject hitParticles;
	public GameObject hitSmoke;

	public GameObject[] pieces;

	public float impactthrustmin;
	public float impactthrustmax;

	private Vector3 lastHitDirection;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDamage(DamageInfo info) {
		Instantiate(hitParticles, info.damageAt, Quaternion.LookRotation(-info.damageDirection));
		Instantiate(hitSmoke, info.damageAt, Quaternion.LookRotation(-info.damageDirection));
		lastHitDirection = info.damageDirection;
	}
	
	void OnDeath() {
		transform.GetComponent<Collider>().isTrigger = true;
		Destroy(GetComponent<Rigidbody>());

		foreach(GameObject p in pieces) {
			p.transform.GetComponent<Collider>().isTrigger = false;
			p.GetComponent<Rigidbody>().isKinematic = false;
			p.GetComponent<Rigidbody>().AddForce(lastHitDirection * Random.Range(impactthrustmin, impactthrustmax));
		}
	}
}
