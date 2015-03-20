using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public ParticleSystem cameraBloodEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDamage(DamageInfo di) {
		cameraBloodEffect.Play();
	}
}
