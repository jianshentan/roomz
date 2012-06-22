using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public float speed = 500;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * -speed;
		//gameObject.transform.Translate(horiz, 0, 0);
		if(Input.GetKey("x")){
			gameObject.transform.Translate(-speed * Time.deltaTime, 0,0);
		}
		if(Input.GetKey("z")){
			gameObject.transform.Translate(speed * Time.deltaTime, 0,0);
		}
		if(Input.GetKey(",")){
			gameObject.transform.Translate(0, 0,speed * Time.deltaTime);
		}
		if(Input.GetKey(".")){
			gameObject.transform.Translate(0, 0,-speed * Time.deltaTime);
		}
	}
}
