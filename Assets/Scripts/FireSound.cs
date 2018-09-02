using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour {
	public float fireRate = 2;
	public float damage = 1;
	public LayerMask notToHit;
	public float longevity;

	public GameObject soundwavePrefab;
	public PlayerMovement playerMovement;
	public MaskController maskCreator;
	
	private float timeSinceShot = 0f;
	private GameObject soundwaveClone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceShot += Time.fixedDeltaTime;
		if (Input.GetButton("Shoot") && timeSinceShot > (1 / fireRate)) {
			timeSinceShot = 0f;
			Shoot();
		}
	}
	
	void Shoot() {
		soundwaveClone = Instantiate(soundwavePrefab, transform.position, Quaternion.identity) as GameObject;
		
		soundwaveClone.GetComponent<SoundwaveScript>().mask = maskCreator;
		
		if (playerMovement.getLastHorizontalMovement() < 0) {
			// Left
			soundwaveClone.GetComponent<SoundwaveScript>().setDirection(false);
			soundwaveClone.GetComponent<SpriteRenderer>().flipX = true;
		}
		else {
			// Right
			soundwaveClone.GetComponent<SoundwaveScript>().setDirection(true);
		}
		
		Destroy(soundwaveClone, longevity);
	}
}
