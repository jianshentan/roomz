using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {
	
	public GameObject cameraX_1;
	public GameObject cameraZ_2;
	public GameObject cameraX_3;
	public GameObject cameraZ_4;	
	public Player player;	
	private string rotationState = "left";
	//[System.NonSerializedAttribute]
	//public bool inputDisabled = false;

	void Start () 
	{
		cameraX_1 = transform.FindChild("CameraX_1").gameObject;
		cameraZ_2 = transform.FindChild("CameraZ_2").gameObject;
		cameraX_3 = transform.FindChild("CameraX_3").gameObject;
		cameraZ_4 = transform.FindChild("CameraZ_4").gameObject;
		
		cameraX_1.SetActiveRecursively(true);
		cameraZ_2.SetActiveRecursively(false);
		cameraX_3.SetActiveRecursively(false);
		cameraZ_4.SetActiveRecursively(false);
	}

	void Update () 
	{
		/*if(!player.getPlayerActive())
		{
			if(Input.GetKeyUp("space"))
			{
				if(rotationState == "left")
					StartCoroutine(rotateLeft());
				else
					StartCoroutine(rotateRight());
			}	
			if(Input.GetKeyUp("left shift"))
			{
				toggleRotationState();
			}
		}
		else
		{
			//Debug.LogWarning("Player is currently active! Action cannot be performed when player is active");	
		}*/
	}
	
	public string getRotationState()
	{
		return 	rotationState;
	}
	
	public void toggleRotationState()
	{
		if(rotationState == "left")
			rotationState = "right";
		else
			rotationState = "left";
		Debug.Log (rotationState);
	}
	
	public void rotateLeft()
	{
		//player.setPlayerActive(true);
		//player.rotate("left");
		//yield return new WaitForSeconds(1f);
		
		if(cameraX_1.active)
		{
			cameraX_1.SetActiveRecursively(false);
			cameraZ_2.SetActiveRecursively(true);
		}
		else if(cameraZ_2.active)
		{
			cameraZ_2.SetActiveRecursively(false);
			cameraX_3.SetActiveRecursively(true);
		}
		else if(cameraX_3.active)
		{
			cameraX_3.SetActiveRecursively(false);
			cameraZ_4.SetActiveRecursively(true);
		}
		else if(cameraZ_4.active)
		{
			cameraZ_4.SetActiveRecursively(false);
			cameraX_1.SetActiveRecursively(true);
		}	
		//yield return new WaitForSeconds(2);
		//player.setPlayerActive(false);
	}
	
	public void rotateRight()
	{
		//player.setPlayerActive(true);
		//player.rotate("right");
		//yield return new WaitForSeconds(1f);
		
		if(cameraX_1.active)
		{
			cameraX_1.SetActiveRecursively(false);
			cameraZ_4.SetActiveRecursively(true);
		}
		else if(cameraZ_2.active)
		{
			cameraZ_2.SetActiveRecursively(false);
			cameraX_1.SetActiveRecursively(true);
		}
		else if(cameraX_3.active)
		{
			cameraX_3.SetActiveRecursively(false);
			cameraZ_2.SetActiveRecursively(true);
		}
		else if(cameraZ_4.active)
		{
			cameraZ_4.SetActiveRecursively(false);
			cameraX_3.SetActiveRecursively(true);
		}
		
		//yield return new WaitForSeconds(2);

		//player.setPlayerActive(false);
	}

	
}
