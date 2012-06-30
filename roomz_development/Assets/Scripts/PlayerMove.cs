using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public DisplayCameraXorZ cam;
	public float speed = 500;

	void Update () {
			if(Input.GetKey("up")){
				gameObject.transform.Translate(speed * Time.deltaTime, 0,0);
			}
			if(Input.GetKey("down")){
				gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
			}
	}
}
