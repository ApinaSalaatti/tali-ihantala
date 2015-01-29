using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour {
	//public GameObject bulletPrefab;
	//public float shootForce = 10f;

	public Weapon rifle;
	public Weapon grenade;

	public Text weaponText;

	private Weapon currentWeapon;

	// Use this for initialization
	void Start () {
		currentWeapon = rifle;
	}

	private void ChangeWeapon(Weapon newWeapon) {
		currentWeapon.TriggerReleased();
		currentWeapon = newWeapon;
		weaponText.text = currentWeapon.gameObject.name;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			ChangeWeapon(rifle);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			ChangeWeapon(grenade);
		}

		if(Input.GetButtonDown("Fire1")) {
			currentWeapon.TriggerPulled();
		}
		if(Input.GetButtonUp("Fire1")) {
			currentWeapon.TriggerReleased();
		}
	}
}
