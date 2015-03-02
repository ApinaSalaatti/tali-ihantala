using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {
	public float delay = 2f;
	public float blastRadius = 5f;
	public float damage = 5f;

	private float timer;

	// Use this for initialization
	void Start () {
		StartCoroutine(Detonate());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator Detonate() {
		// Wait the set time
		yield return new WaitForSeconds(delay);

		// EXPLODE!! (i.e. find all gameobjects that are in the blast radius and HURT them)
		int layerMask = LayerMask.GetMask("Destroyable", "Enemy");
		Collider[] cols = Physics.OverlapSphere(transform.position, blastRadius, layerMask);
		foreach(Collider col in cols) {
			if(col.gameObject != gameObject)
				col.gameObject.SendMessage("TakeDamage", damage);
		}

		Destroy(gameObject);
	}
}
