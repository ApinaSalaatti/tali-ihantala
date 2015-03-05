using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {
	public float timeBetweenShots = 0.9f;

	protected int specialAmmoLeft = 5;
	protected bool usingSpecialAmmo;
	public int AmmoLeft {
		get {
			if(usingSpecialAmmo)
				return specialAmmoLeft;
			else
				return -1; // -1 means infinite ammo
		}
	}
	public int SpecialAmmoLeft {
		get {
			return specialAmmoLeft;
		}
	}
	public void AddSpecialAmmo(int amount) {
		specialAmmoLeft += amount;
	}

	public GameObject bulletPrefab;
	public GameObject specialBulletPrefab;

	protected bool firing = false;
	private float fireTimer = 1f;

	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;
		WeaponUpdate();

		// If we run out of special ammo, automatically change back to normal ammo
		if(usingSpecialAmmo && specialAmmoLeft == 0)
			ChangeAmmoType();

		if(firing) {
			if(fireTimer >= timeBetweenShots && AmmoLeft != 0) {
				if(usingSpecialAmmo) specialAmmoLeft--;
				fireTimer = 0f;
				Fire();
			}
		}
	}

	public void AimAt(Vector3 target) {
		transform.LookAt(target);
	}

	public void TriggerPulled() {
		firing = true;
	}

	public void TriggerReleased() {
		firing = false;
	}

	public virtual GameObject GetActiveAmmo ()
	{
		if(usingSpecialAmmo) {
			return specialBulletPrefab;
		}
		else {
			return bulletPrefab;
		}
	}
	
	public virtual void ChangeAmmoType ()
	{
		usingSpecialAmmo = !usingSpecialAmmo;
	}

	protected abstract void Fire();
	protected virtual void WeaponUpdate() {
	}
}
