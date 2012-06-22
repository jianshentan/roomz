using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float camera_relative_xpos;
	public float camera_relative_ypos;
	public float camera_relative_zpos;
	
	void Start () {
	}
	
	void Update () {
		if(!target){
			Debug.LogError("No target to follow");	
		}
		Vector3 cameraPos = target.position;
		cameraPos.x -= camera_relative_xpos;
		cameraPos.y += camera_relative_ypos;
		cameraPos.z += camera_relative_zpos;
		transform.position = cameraPos;
		//transform.position.Set(target.position.x, target.position.y, target.position.z);
	}
}
