using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour {
	public GameObject maskPrefab;
	private GameObject maskClone;
	
	public float duration;
	public float scalePerSecond;

	public void SoundPing(Vector3 location) {
		maskClone = Instantiate(maskPrefab, location, Quaternion.identity) as GameObject;
	}
}
