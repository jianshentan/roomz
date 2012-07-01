using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public SwitchCamera cam;
	public float speed;
	public float rotateSpeed;
	private bool isRotating_Left = false;
	private bool isRotating_Right = false;
	private Quaternion rotate_start;
	private Quaternion rotate_end;
	
	void Update () {
		// ---moving forward and backwards---
		if(!isRotating_Left && !isRotating_Right){ //-while not rotating
			if(Input.GetKey("up")){
				gameObject.transform.Translate(-speed * Time.deltaTime, 0,0);
			}
			if(Input.GetKey("down")){
				gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
			}
		}
		
		// ---rotating---
		if(isRotating_Left){
			transform.Rotate(0,-90f*Time.deltaTime*rotateSpeed,0);
			rotate_end = transform.rotation;
			if(Quaternion.Angle(rotate_start, rotate_end) > 90){
				isRotating_Left = false;	
			}
		}
		if(isRotating_Right){
			transform.Rotate(0,90f*Time.deltaTime*rotateSpeed, 0);
			rotate_end = transform.rotation;
			if(Quaternion.Angle(rotate_start,rotate_end) > 90){
				isRotating_Right = false;
			}
			
		}
		
	}
	
	public void rotateLeft(){
		rotate_start = transform.rotation;
		isRotating_Left = true;
	}
	
	public void rotateRight(){
		rotate_start = transform.rotation;
		isRotating_Right = true;
	}
	
	IEnumerator Rotation (Transform thisTransform, Vector3 degrees, float time) {
	    Quaternion startRotation = thisTransform.rotation;
	    Quaternion endRotation = thisTransform.rotation * Quaternion.Euler(degrees);
	    float rate = 1/time;
	    float t = 0;
	    while (t < 1.0) {
	        t += Time.deltaTime * rate;
	        thisTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
			yield return t; 
   		}
	}
}
