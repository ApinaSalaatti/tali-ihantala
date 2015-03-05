using UnityEngine;
using System.Collections.Generic;

public class BuffManager : MonoBehaviour {
	private List<Buff> activeBuffs;

	// Use this for initialization
	void Start () {
		activeBuffs = new List<Buff>();
	}
	
	// Update is called once per frame
	void Update () {
		List<Buff> toRemove = new List<Buff>();

		foreach(Buff b in activeBuffs) {
			b.Update();
			if(b.Done)
				toRemove.Add(b);
		}

		// Remove the completed buffs in a separate loop so we don't modify the activeBuffs list while iterating through it (it always causes problems :I)
		foreach(Buff b in toRemove) {
			b.OnRemove();
			activeBuffs.Remove(b);
		}
		toRemove.Clear();
	}

	public void AddBuff(Buff  b) {
		Debug.Log("Adding buff");
		activeBuffs.Add(b);
		b.OnAdd(gameObject);
	}
}
