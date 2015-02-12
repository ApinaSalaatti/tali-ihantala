using UnityEngine;
using System.Collections;

public class Sunmove : MonoBehaviour 
{
	public float Windspeed;
	public float resetpoint;


	void Update() 
	{
		if (transform.position.x < resetpoint) {
			transform.Translate (Vector3.right * Time.deltaTime*Windspeed);
		} 

		else 
		{
			transform.Translate (-Vector3.right * 2f *resetpoint);
		}
	}
}