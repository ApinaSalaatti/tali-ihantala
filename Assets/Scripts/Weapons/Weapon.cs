using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {
	public float timeBetweenShots = 0.9f;

	protected bool firing = false;
	private float fireTimer = 1f;

	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;
		WeaponUpdate();

		if(firing) {
			if(fireTimer >= timeBetweenShots) {
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

	// Please override this rather than using Update().
	protected virtual void WeaponUpdate() {

	}

	protected abstract void Fire();
}
