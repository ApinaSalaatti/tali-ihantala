using UnityEngine;
using System.Collections;

public class DestroyObjectsInteraction : Interaction {
	public GameObject[] objectsToDestroy;
	public float delay = 0f;
	public bool destroySelf = false;

	private bool objectsDestroyed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Interact (GameObject interacter)
	{
		if(!objectsDestroyed) {
			foreach(GameObject o in objectsToDestroy) {
				Destroy(o, delay);
			}

			if(destroySelf) Destroy(gameObject, delay);

			objectsDestroyed = true;
		}
	}
}
