using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {
	
	public GameObject cameraX_1;
	public GameObject cameraZ_2;
	public GameObject cameraX_3;
	public GameObject cameraZ_4;	
	
	public Transform player;	
	
	private string rotationState = "left";
	
	public string getRotationState(){
		return 	rotationState;
	}
	
	void Start () {
		cameraX_1 = transform.FindChild("CameraX_1").gameObject;
		cameraZ_2 = transform.FindChild("CameraZ_2").gameObject;
		cameraX_3 = transform.FindChild("CameraX_3").gameObject;
		cameraZ_4 = transform.FindChild("CameraZ_4").gameObject;
		
		cameraX_1.SetActiveRecursively(true);
		cameraZ_2.SetActiveRecursively(false);
		cameraX_3.SetActiveRecursively(false);
		cameraZ_4.SetActiveRecursively(false);
	}

	void Update () {
		if(Input.GetKeyUp("space")){
			if(rotationState == "left")
				StartCoroutine(rotateLeft());
			else
				StartCoroutine(rotateRight());
		}	
		if(Input.GetKeyUp("left shift")){
			toggleRotationState();
		}
	}
	
	public void toggleRotationState(){
		if(rotationState == "left")
			rotationState = "right";
		else
			rotationState = "left";
	}
	
	IEnumerator rotateLeft(){
		player.GetComponent<PlayerMove>().rotateLeft();
		
		yield return new WaitForSeconds(1.5f);

		if(cameraX_1.active){
			cameraX_1.SetActiveRecursively(false);
			cameraZ_2.SetActiveRecursively(true);
		}
		else if(cameraZ_2.active){
			cameraZ_2.SetActiveRecursively(false);
			cameraX_3.SetActiveRecursively(true);
		}
		else if(cameraX_3.active){
			cameraX_3.SetActiveRecursively(false);
			cameraZ_4.SetActiveRecursively(true);
		}
		else if(cameraZ_4.active){
			cameraZ_4.SetActiveRecursively(false);
			cameraX_1.SetActiveRecursively(true);
		}	
	}
	
	IEnumerator rotateRight(){
		player.GetComponent<PlayerMove>().rotateRight();
		
		yield return new WaitForSeconds(1.5f);

		if(cameraX_1.active){
			cameraX_1.SetActiveRecursively(false);
			cameraZ_4.SetActiveRecursively(true);
		}
		else if(cameraZ_2.active){
			cameraZ_2.SetActiveRecursively(false);
			cameraX_1.SetActiveRecursively(true);
		}
		else if(cameraX_3.active){
			cameraX_3.SetActiveRecursively(false);
			cameraZ_2.SetActiveRecursively(true);
		}
		else if(cameraZ_4.active){
			cameraZ_4.SetActiveRecursively(false);
			cameraX_3.SetActiveRecursively(true);
		}	
	}
	
}
