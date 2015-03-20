using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class CleanDestroyableObject : MonoBehaviour 
{

	public GameObject hitParticles;
	public GameObject hitSmoke;

	// Use this for initialization
	void Start () 
	{
	}

	// Update is called once per frame
	void Update () 
	{
	}

	void OnDamage(DamageInfo info) 
	{
		Instantiate(hitParticles, info.damageAt, Quaternion.LookRotation(-info.damageDirection));
		Instantiate(hitSmoke, info.damageAt, Quaternion.LookRotation(-info.damageDirection));
	}
	void OnDeath() 
	{
		Destroy(gameObject);
	}
}