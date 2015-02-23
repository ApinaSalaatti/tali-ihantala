using UnityEngine;
using System.Collections;

public class ShopScreen : GameScreen {
	private PlayerWeaponController weaponController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyGrenade() {
		weaponController.grenade.ammoLeft++;
	}

	public void SetShopper(GameObject shopper) {
		weaponController = shopper.GetComponent<PlayerWeaponController>();
	}
}
