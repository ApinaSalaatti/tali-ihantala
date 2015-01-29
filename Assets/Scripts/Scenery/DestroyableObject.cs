using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {
	public float health = 1f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void TakeDamage(float damage) {
		health -= damage;
		if(health <= 0f) {
			Destroy(gameObject);
		}
	}
}
