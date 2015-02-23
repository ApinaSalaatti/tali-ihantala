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
		currentWeapon.TriggerPulled();
	}
	void ReleaseTrigger() {
		currentWeapon.TriggerReleased();
	}
	void ChangeWeapon() {
		ToggleWeapon();
	}
}
