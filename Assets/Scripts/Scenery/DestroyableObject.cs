﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class DestroyableObject : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnDeath() {
		Destroy(gameObject);
	}
}
