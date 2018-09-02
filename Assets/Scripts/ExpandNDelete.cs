using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandNDelete : MonoBehaviour {
	public float duration;
	public float scalePerSecond;
	
	void Start () {
		transform.localScale = new Vector3(0.01F, 0.01F, 0);
		Destroy(gameObject, duration);
	}
	
	void Update () {
		// Expand outwards
		transform.localScale += new Vector3(scalePerSecond, scalePerSecond, 0);
	}
}
