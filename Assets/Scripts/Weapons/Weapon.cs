using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {
	public float timeBetweenShots = 0.9f;

	private bool firing = false;
	private float fireTimer = 1f;

	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;

		if(firing) {
			if(fireTimer >= timeBetweenShots) {
				fireTimer = 0f;
				Fire();
			}
		}
	}

	public void TriggerPulled() {
		firing = true;
	}

	public void TriggerReleased() {
		firing = false;
	}

	protected abstract void Fire();
}
