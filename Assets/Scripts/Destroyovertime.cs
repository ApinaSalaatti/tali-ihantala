using UnityEngine;
using System.Collections;

public class Destroyovertime : MonoBehaviour
{
	public float lifetime;
	
	void Start()
	{
		Destroy (gameObject, lifetime);
	}
}