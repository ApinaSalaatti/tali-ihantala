using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	public float scrollSpeed = 0.05F;
	public Renderer rend;


	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 15));
		rend.material.SetTextureOffset("_MainTex", new Vector2(15, offset));
	}
}