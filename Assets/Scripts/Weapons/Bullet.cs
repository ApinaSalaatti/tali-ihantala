using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float damage;
	public GameObject smoke;
	public GameObject flash;
	public GameObject bloodspill;
	public GameObject bloodcloud;

	// Use this for initialization
	void Start () {
	
	}

	void Update() {

	}

	private void HitObject(GameObject go) {
		go.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

		BulletEffect[] effects = GetComponents<BulletEffect>();
		foreach(BulletEffect e in effects) {
			e.Affect(go);


		}

		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col) {

			HitObject (col.collider.gameObject);

		//tuo flashi pitäs saada syntyyn luodin suunan vastaiseen suuntaan ja veriroiskeet samaan suuntaan... mitenkähän se onnistuis?
		//nää elottomaan:
		Instantiate (smoke, transform.position, transform.rotation);
		Instantiate (flash, transform.position, transform.rotation);

		//nää kaikkeen elävään:
		//Instantiate (bloodcloud, transform.position, transform.rotation);
		//Instantiate (bloodspill, transform.position, transform.rotation);
		
	}
}
