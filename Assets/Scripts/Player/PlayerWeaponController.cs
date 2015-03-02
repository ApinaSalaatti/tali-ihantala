using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour {
	public Weapon rifle;
	public Weapon grenade;

	private Weapon currentWeapon;
	public Weapon CurrentWeapon {
		get {
			return currentWeapon;
		}
	}

	// When showing middle finger, can't shoot
	private bool isShowingMiddleFinger = false;

	// Use this for initialization
	void Start () {
		currentWeapon = rifle;
	}

	public void AimAt(Vector3 target) {
		currentWeapon.AimAt(target);
	}

	private void SetWeapon(Weapon newWeapon) {
		currentWeapon.TriggerReleased();
		currentWeapon = newWeapon;
	}
	private void ToggleWeapon() {
		if(currentWeapon == rifle) SetWeapon(grenade);
		else SetWeapon(rifle);
	}

	// Update is called once per frame
	void Update () {

	}

	void PullTrigger() {
		if(!isShowingMiddleFinger) {
			currentWeapon.TriggerPulled();
			GetComponent<Animator>().SetBool("Shooting", true);
		}
	}
	void ReleaseTrigger() {
		currentWeapon.TriggerReleased();
		GetComponent<Animator>().SetBool("Shooting", false);
	}
	void ChangeWeapon() {
		ToggleWeapon();
	}

	void ChangeAmmoType() {
		currentWeapon.ChangeAmmoType();
	}

	void ShowingMiddleFinger() {
		isShowingMiddleFinger = true;
		ReleaseTrigger();
	}

	void NotShowingMiddleFinger() {
		isShowingMiddleFinger = false;
	}
}
