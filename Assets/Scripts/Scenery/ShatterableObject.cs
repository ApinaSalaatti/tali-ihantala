using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class ShatterableObject : MonoBehaviour {
	public GameObject hitParticles;
	public GameObject hitSmoke;
	public GameObject piece1;
	public GameObject piece2;
	public GameObject piece3;
	public GameObject piece4;
	public GameObject piece5;
	public GameObject piece6;
	public GameObject piece7;
	public GameObject piece8;
	public GameObject piece9;
	public GameObject piece10;
	public GameObject piece11;
	public GameObject piece12;
	public GameObject piece13;
	public GameObject piece14;
	public GameObject piece15;
	public GameObject piece16;
	public GameObject piece17;
	public GameObject piece18;
	public GameObject piece19;
	public float impactthrustmin;
	public float impactthrustmax;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDamage(DamageInfo info) {
		Instantiate(hitParticles, info.damageAt, Quaternion.LookRotation(-info.damageDirection));
		Instantiate(hitSmoke, info.damageAt, Quaternion.LookRotation(-info.damageDirection));
	}
	
	void OnDeath() {
		transform.collider.isTrigger = true;
		Destroy(rigidbody);

		piece1.transform.collider.isTrigger = false;
		piece1.rigidbody.isKinematic = false;
		piece1.rigidbody.AddForce(Vector3.up* Random.Range (impactthrustmin, impactthrustmax));

		piece2.transform.collider.isTrigger = false;
		piece2.rigidbody.isKinematic = false;
		piece2.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece3.transform.collider.isTrigger = false;
		piece3.rigidbody.isKinematic = false;
		piece3.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece4.transform.collider.isTrigger = false;
		piece4.rigidbody.isKinematic = false;
		piece4.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece5.transform.collider.isTrigger = false;
		piece5.rigidbody.isKinematic = false;
		piece5.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece6.transform.collider.isTrigger = false;
		piece6.rigidbody.isKinematic = false;
		piece6.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece7.transform.collider.isTrigger = false;
		piece7.rigidbody.isKinematic = false;
		piece7.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece8.transform.collider.isTrigger = false;
		piece8.rigidbody.isKinematic = false;
		piece8.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece9.transform.collider.isTrigger = false;
		piece9.rigidbody.isKinematic = false;
		piece9.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece10.transform.collider.isTrigger = false;
		piece10.rigidbody.isKinematic = false;
		piece10.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece11.transform.collider.isTrigger = false;
		piece11.rigidbody.isKinematic = false;
		piece11.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece12.transform.collider.isTrigger = false;
		piece12.rigidbody.isKinematic = false;
		piece12.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece13.transform.collider.isTrigger = false;
		piece13.rigidbody.isKinematic = false;
		piece13.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece14.transform.collider.isTrigger = false;
		piece14.rigidbody.isKinematic = false;
		piece14.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece15.transform.collider.isTrigger = false;
		piece15.rigidbody.isKinematic = false;
		piece15.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece16.transform.collider.isTrigger = false;
		piece16.rigidbody.isKinematic = false;
		piece16.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece17.transform.collider.isTrigger = false;
		piece17.rigidbody.isKinematic = false;
		piece17.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece18.transform.collider.isTrigger = false;
		piece18.rigidbody.isKinematic = false;
		piece18.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

		piece19.transform.collider.isTrigger = false;
		piece19.rigidbody.isKinematic = false;
		piece19.rigidbody.AddForce(Vector3.up * Random.Range (impactthrustmin, impactthrustmax));

	}
}
