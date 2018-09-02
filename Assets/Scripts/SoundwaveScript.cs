using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundwaveScript : MonoBehaviour {
	public float velocity = 5f;
	public bool right;
	public MaskController mask;
	
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		mask.SoundPing(transform.position);
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (right) {
			rb.velocity = new Vector2(velocity, 0);
		}
		else {
			rb.velocity = new Vector2(-(velocity), 0);
		}
	}
	
	public void setVelocity(float inVelocity) {
		velocity = inVelocity;
	}
	
	public void setDirection(bool inRight) {
		right = inRight;
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		mask.SoundPing(transform.position);
		Destroy(gameObject);
	}
}
