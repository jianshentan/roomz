using UnityEngine;
using System.Collections;

public class DisplayCameraXorZ : MonoBehaviour {
	
	public GameObject cameraX;
	public GameObject cameraZ;
		
	// Use this for initialization
	void Start () {
		cameraX = transform.FindChild("CameraX").gameObject;
		cameraZ = transform.FindChild("CameraZ").gameObject;
		cameraX.SetActiveRecursively(true);
		cameraZ.SetActiveRecursively(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("space")){
			if(cameraX.active){
				cameraX.SetActiveRecursively(false);
				cameraZ.SetActiveRecursively(true);
			}else{
				cameraX.SetActiveRecursively(true);
				cameraZ.SetActiveRecursively(false);
			}
		}
		
	}
}
