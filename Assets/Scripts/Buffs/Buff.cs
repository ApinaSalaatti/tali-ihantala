using UnityEngine;
using System.Collections;

public abstract class Buff {
	public string BuffName {
		get; set;
	}
	protected GameObject affectedObject;
	public bool Done {
		get; set;
	}
	// Length of the buff in seconds. < 0 means infinite
	public float Length {
		get; set;
	}
	public float TimeLeft {
		get; set;
	}

	public Buff(string name, float length) {
		BuffName = name;
		Length = length;
		TimeLeft = length;
	}

	public void Update() {
		BuffUpdate();
		if(TimeLeft > 0) {
			TimeLeft -= Time.deltaTime;
			if(TimeLeft <= 0) {
				Done = true;
			}
		}
	}

	public void OnAdd(GameObject obj) {
		affectedObject = obj;
	}
	public void OnRemove() {

	}

	public abstract void BuffUpdate();
}
