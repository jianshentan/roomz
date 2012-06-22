using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision theCollision){
		Debug.Log("Collision Detected!");
	}
}
