using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public GameObject foodObj;

	float foodLaunchRate = .1f;
	float foodLaunchTimer;

	// Use this for initialization
	void Start () {
		foodLaunchTimer = foodLaunchRate;
	}

	// Update is called once per frame
	void Update () {	
		foodLaunchTimer -= Time.deltaTime;
		if (Input.GetKey(KeyCode.C) && foodLaunchTimer < 0) {
			//Reset the food launch timer
			foodLaunchTimer = foodLaunchRate;

			GameObject food = (GameObject)GameObject.Instantiate(foodObj, transform.position, Quaternion.identity);
			//Shoot the food in the direction that the Food Launcher is shooting
			Rigidbody rb = food.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 5000);

			//Destroy the bullet in 2 seconds
			Destroy (food, 2f);
		}
	}
}