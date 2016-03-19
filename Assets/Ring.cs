using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {
	public GameObject RingObj; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 startPosition = new Vector3 ();

	
	}
	void OnTriggerEnter(Collider other) {
		//If we collide with the out of bounds trigger, turn off gravity
		//and remove all velocity
		if (other.name == "Trigger") {
			GameObject Ring = (GameObject)GameObject.Instantiate (RingObj, transform.position * 10 * Time.deltaTime, Quaternion.identity);
			Rigidbody rb = Ring.GetComponent<Rigidbody> ();
			rb.useGravity = false;
		}
	}
}
