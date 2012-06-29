using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public DisplayCameraXorZ cam;
	public float speed = 500;
	
	// Use this for initialization
	void Start () {
		//DisplayCameraXorZ cam = cameraXZ.GetComponent<DisplayCameraXorZ>();
	}
	
	// Update is called once per frame
	void Update () {
		if(cam.cameraZ.active)
		{
			if(Input.GetKey("up")){
				gameObject.transform.Translate(0, 0,speed * Time.deltaTime);
			}
			if(Input.GetKey("down")){
				gameObject.transform.Translate(0, 0,-speed * Time.deltaTime);
			}
		}
		else
		{
			if(Input.GetKey("up")){
				gameObject.transform.Translate(speed * Time.deltaTime, 0,0);
			}
			if(Input.GetKey("down")){
				gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
			}
		}
	}
}
