using UnityEngine;
using System.Collections;

public class Collision_Front : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collider){
		Debug.Log ("Front plane has collided with: " + collider);	
	}	
}
