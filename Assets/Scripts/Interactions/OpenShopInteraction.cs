using UnityEngine;
using System.Collections;

public class OpenShopInteraction : Interaction {
	public ShopScreen shop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Interact (GameObject interacter)
	{
		shop.SetShopper(interacter);
		shop.Open();
	}
}
