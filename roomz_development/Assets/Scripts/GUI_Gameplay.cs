using UnityEngine;
using System.Collections;

public class GUI_Gameplay : MonoBehaviour 
{
	
	public GUIStyle customButton;
	public Texture2D rotateDirectionIcon_Left;
	public Texture2D rotateDirectionIcon_Right;
	public SwitchCamera mainCamera;
	public Player player;
	
	public Camera topCamera;
	public Camera bottomCamera;
	
	void OnGUI()
	{
		//this shows the toggle state
		/*string rotateState = mainCamera.getRotationState();
		
		if(rotateState == "left")
		{
			if(GUI.Button (new Rect(Screen.width/10 * 8.3f,50,50,50), rotateDirectionIcon_Left, customButton))
			{
				mainCamera.toggleRotationState();
			}
		}
		else
		{
			if(GUI.Button (new Rect(Screen.width/10 * 8.3f,50,50,50), rotateDirectionIcon_Right, customButton))
			{
				mainCamera.toggleRotationState();
			}
		}*/
		
		Rect topCam = topCamera.pixelRect;
		topCam.y = Screen.height - topCam.y - 60;
		
		Rect bottomCam = bottomCamera.pixelRect;
		bottomCam.y = Screen.height - bottomCam.y - 60;
		
		if (GUI.Button(topCam, "" , customButton))
		{
			mainCamera.setRotationState("left");
			player.rotate();
		}
		if (GUI.Button(bottomCam, "", customButton))
		{
			mainCamera.setRotationState("right");
			player.rotate();
		}
		
	}
}
