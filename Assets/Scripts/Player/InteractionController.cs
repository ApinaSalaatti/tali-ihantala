using UnityEngine;
using System.Collections;

public class InteractionController : MonoBehaviour {
	public float interactionRadius = 5f;
	public GameObject interactionMarker;

	Interaction closestInteraction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		Collider[] cols = Physics.OverlapSphere(transform.position, interactionRadius);

		// Find the closest GameObject with an Interaction-component (if any)
		float closestDist = float.MaxValue;
		Interaction closest = null;
		foreach(Collider col in cols) {
			Interaction i = col.gameObject.GetComponent<Interaction>();
			if(i != null) {
				float dist = Vector3.Distance(transform.position, i.gameObject.transform.position);
				if(dist < closestDist) {
					closest = i;
					closestDist = dist;
				}
			}
		}

		closestInteraction = closest;
		// Place a cool exclamation mark above the interaction
		if(closestInteraction != null) {
			float s = interactionRadius - Vector3.Distance(transform.position, closestInteraction.transform.position);
			s = Mathf.Max(0f, s);
			s = Mathf.Min(1f, s);
			interactionMarker.transform.localScale = new Vector3(s, s, s);
			interactionMarker.transform.position = closestInteraction.transform.position + new Vector3(0f, 2.5f, 0f);
		}
		else {
			interactionMarker.transform.localScale = Vector3.zero;
		}
	}

	void Interact() {
		if(closestInteraction != null) {
			closestInteraction.Interact(gameObject);
		}
	}
}
