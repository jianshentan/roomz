using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	private Transform target;
	public float camera_relative_xpos;
	public float camera_relative_ypos;
	public float camera_relative_zpos;
	
	void Start () 
	{
		//this gets the targeted player set in the parent, parent gameobject
		target = transform.parent.parent.GetComponent<SwitchCamera>().player.gameObject.transform;
	}
	
	void Update () 
	{
		if(!target)
		{
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
