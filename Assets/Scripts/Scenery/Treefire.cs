using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class Treefire : MonoBehaviour 
{

	public ParticleSystem particle1;
	public ParticleSystem particle2;
	public float burnfloat;
	private bool burned = false;
	
	// Use this for initialization
	void Start () 
	{
	}

	
	void OnDamage(DamageInfo info) 
	{
		Debug.Log("HELLO");
		if(info.damageType == DamageType.EXPLOSION || info.damageType == DamageType.FIRE) {
			StartFire();
		}
	}

	private void StartFire() {
		if (burned == false) 
		{
			particle1.Play ();
			particle2.Play ();
			
			burned = true;
		}
	}

	void OnTriggerEnter(Collider c) {
		Debug.Log("TREE HIT!");
		// Check if we were hit with something that does fire damage
		BulletEffect[] effects = c.gameObject.GetComponents<BulletEffect>();
		foreach(BulletEffect be in effects) {
			if(be.damageType == DamageType.FIRE || be.damageType == DamageType.EXPLOSION) {
				StartFire();
			}
		}
	}

	void FixedUpdate () 
	{
		if (burned == true)
		{
			//Debug.Log ("puu on palanut");
			GetComponent<Renderer>().material.color = Color.Lerp (GetComponent<Renderer>().material.color, Color.black, Time.deltaTime*burnfloat);
		}
	}

	void OnDeath() 
	{
	}
}