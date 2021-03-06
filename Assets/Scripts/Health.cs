﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float maxHealth = 10;
	
	private float health;
	public float CurrentHealth {
		get {
			return health;
		}
		set {
			health = value;
		}
	}
	
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Heal(float amount) {
		CurrentHealth += amount;
		if(CurrentHealth > maxHealth) {
			CurrentHealth = maxHealth;
		}
	}
	
	void TakeDamage(DamageInfo info) {
		health -= info.damageAmount;
		gameObject.SendMessage("OnDamage", info, SendMessageOptions.DontRequireReceiver);

		if(health <= 0f) {
			gameObject.SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
		}

		//Debug.Log("HEALTH LEFT: " + CurrentHealth);
	}
}
