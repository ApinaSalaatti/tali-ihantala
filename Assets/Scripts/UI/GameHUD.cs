﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHUD : MonoBehaviour {
	public GameObject player;

	public Text healthText;
	public Text weaponText;

	private Health playerHealth;
	private PlayerWeaponController weaponController;

	// Use this for initialization
	void Start () {
		playerHealth = player.GetComponent<Health>();
		weaponController = player.GetComponent<PlayerWeaponController>();
	}
	
	// Update is called once per frame
	void Update () {
		weaponText.text = weaponController.CurrentWeapon.name;
		healthText.text = "Health: " + playerHealth.CurrentHealth;
	}
}
