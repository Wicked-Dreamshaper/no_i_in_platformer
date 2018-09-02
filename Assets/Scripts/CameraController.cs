using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform playerLocation;

	private Vector3 original;
	private float width;
	
	// Use this for initialization
	void Start () {
		original = transform.position;
		width = Screen.width;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(playerLocation.position.x, original.y, original.z);
	}
}
