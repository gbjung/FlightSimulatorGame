using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

	//This variable will be modified based on the where the plane is facing (up and down)
	float speed = 5f;

	float rotateSpeed = 35f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Draw a line on the window. This is useful just so you know where the plane is facing
		//You would remove this when the game is finished being debugged
		Debug.DrawRay (transform.position, transform.forward * 1000);

		//Get input information
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");

		//Create a vector that will store how much we are going to rotate the plane
		//on this update call
		Vector3 amountToRotate = new Vector3 (-vAxis, 0, -hAxis);
		amountToRotate *= rotateSpeed;
		amountToRotate *= Time.deltaTime;
		transform.Rotate (amountToRotate);

		//Increase speed if the space bar is pressed (the 'gas pedal')
		if (Input.GetKey (KeyCode.Space)) {
			speed += 50 * Time.deltaTime;
		}

		//Either increase of decrease the speed based on whether the plane is facing up or down
		//Note: we get how much the plane is facing up or down from the transform's forward.y value
		speed -= transform.forward.y * 25 * Time.deltaTime;

		//Limit the speed to be between 0 and 10
		speed = Mathf.Clamp (speed, 0, 10);

		//Always move the plane foward at the rate of 'speed'
		Vector3 amountToMove = transform.forward * speed;
		amountToMove *= Time.deltaTime;
		transform.Translate (amountToMove, Space.World);

		//Keep the plane from going through the ground
		float terrainHeight = Terrain.activeTerrain.SampleHeight (transform.position);
		if (transform.position.y < terrainHeight + 2) {
			transform.position = new Vector3(transform.position.x, terrainHeight + 2, transform.position.z);
		}

		//Update Camera's position
		//Note: this is done to make it so the camera doesn't rotate when the plane rotates
		//Note: the Main Camera is no a child of the plane
		Camera.main.transform.position = transform.position - transform.forward * 10 + Vector3.up * 4;
		Camera.main.transform.LookAt (transform.position);
	}
}








