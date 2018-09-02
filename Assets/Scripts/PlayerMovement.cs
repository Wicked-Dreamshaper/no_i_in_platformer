using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Objects
	public CharacterController2D controller;

	// Public Variables
	public float runSpeed = 40f;
	public float timeBetweenSteps = 0.50f;
	
	private float horizontalMovement = 0f;
	private bool jump = false;
	private bool crouch = false;
	
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
		
		// Walking sounds code
		if (horizontalMovement != 0) {
			if (timePassed == 0f) {
				// Just started walking (or shortly after)
			}
			
			timePassed += Time.fixedDeltaTime;
			if (timePassed > timeBetweenSteps) {
				// Has been walking for a bit
				timePassed = 0f;
			}
		}
		else {
			// Not walking
			timePassed = 0f;
		}
	}
}
