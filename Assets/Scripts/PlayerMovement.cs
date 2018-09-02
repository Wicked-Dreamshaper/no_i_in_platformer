using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Objects
	public CharacterController2D controller;
	public MaskController mask;

	// Public Variables
	public float runSpeed = 40f;
	public float timeBetweenSteps = 0.50f;
	
	private float horizontalMovement = 0f;
	private float lastHorizontalMovement= 1f;
	private bool jump = false;
	private bool crouch = false;
	private Rigidbody2D rb;
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	private float timePassed = 0f;
	// Update is called once per frame
	void Update () {
		horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
	
		if (Input.GetButtonDown("Jump")) {
			jump = true;
		}
		
		if (Input.GetButtonDown("Crouch")) {
			crouch = true;
		}
		if (Input.GetButtonUp("Crouch")) {
			crouch = false;
		}
	}
	
	void FixedUpdate() {
		controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
		jump = false;
		
		// Update last horizontal movement
		if (horizontalMovement != 0) {
			// Store the last movement the character has made
			lastHorizontalMovement = horizontalMovement;
		}
		
		// Walking sounds code
		if (rb.velocity.y == 0f)
		{
			if (horizontalMovement != 0) {
				if (timePassed == 0f) {
					// Just started walking (or shortly after)
					mask.SoundPing(transform.position);
				}
				
				timePassed += Time.fixedDeltaTime;
				if (timePassed > timeBetweenSteps) {
					// Has been walking for a bit
					mask.SoundPing(transform.position);
					timePassed = 0.001f;
				}
			}
			else {
				// Not walking
				timePassed = 0f;
			}
		}
	}
	
	// Returns x<0 for left, x>0 for right
	public float getLastHorizontalMovement() {
		return lastHorizontalMovement;
	}
}
