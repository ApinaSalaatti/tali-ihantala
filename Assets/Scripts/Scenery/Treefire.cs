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

		if (burned == false) 
		{
			particle1.Play ();
			particle1.Play ();

			burned = true;
		}
	}

	void FixedUpdate () 
	{
		if (burned == true)
		{
			Debug.Log ("puu on palanut");
			renderer.material.color = Color.Lerp (renderer.material.color, Color.black, Time.deltaTime*burnfloat);
		}
	}

	void OnDeath() 
	{
	}
}