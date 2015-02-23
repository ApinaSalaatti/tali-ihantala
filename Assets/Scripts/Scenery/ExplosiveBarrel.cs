using UnityEngine;
using System.Collections;

public class ExplosiveBarrel : MonoBehaviour {
	public float blastRadius = 5f;
	public float damage = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy() {
		Debug.Log("BOOM EXPLOSION!!");

		// EXPLODE!! (i.e. find all gameobjects that are in the blast radius and HURT them)
		int layerMask = LayerMask.GetMask("Destroyable", "Enemy", "Player");
		Collider[] cols = Physics.OverlapSphere(transform.position, blastRadius, layerMask);
		foreach(Collider col in cols) {
			col.gameObject.SendMessage("TakeDamage", damage);
		}
		
		Destroy(gameObject);
	}
}
