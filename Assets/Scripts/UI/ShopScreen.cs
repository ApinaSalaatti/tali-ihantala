using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopScreen : GameScreen {
	private PlayerWeaponController weaponController;
	private ResourceManager resourceManager;

	public Text moneyText;
	public Text buyAmmoText;

	public int specialAmmoPrice = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(resourceManager != null)
			moneyText.text = "Money left: " + resourceManager.Money;

		if(weaponController != null)
			buyAmmoText.text = "Buy Ammo (" + weaponController.CurrentWeapon.SpecialAmmoLeft + ")";
	}

	public void SetAmmoType(GameObject ammo) {
		weaponController.CurrentWeapon.specialBulletPrefab = ammo;
	}
	public void BuySpecialAmmo() {
		if(resourceManager.Money >= specialAmmoPrice) {
			resourceManager.Money -= specialAmmoPrice;
			weaponController.CurrentWeapon.AddSpecialAmmo(1);
		}
	}

	public void SetShopper(GameObject shopper) {
		weaponController = shopper.GetComponent<PlayerWeaponController>();
		resourceManager = shopper.GetComponent<ResourceManager>();
	}
}
