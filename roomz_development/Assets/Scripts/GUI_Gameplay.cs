using UnityEngine;
using System.Collections;

public class GUI_Gameplay : MonoBehaviour 
{
	
	public GUIStyle customButton;
	
	public Texture2D rotateDirectionIcon_Left;
	public Texture2D rotateDirectionIcon_Right;
	public GameObject mainCamera;
	
	void OnGUI()
	{
		string rotateState = mainCamera.GetComponent<SwitchCamera>().getRotationState();
		
		if(rotateState == "left")
		{
			if(GUI.Button (new Rect(Screen.width/10 * 8.3f,50,50,50), rotateDirectionIcon_Left, customButton))
			{
				mainCamera.GetComponent<SwitchCamera>().toggleRotationState();
			}
		}
		else
		{
			if(GUI.Button (new Rect(Screen.width/10 * 8.3f,50,50,50), rotateDirectionIcon_Right, customButton))
			{
				mainCamera.GetComponent<SwitchCamera>().toggleRotationState();
			}
		}
	}
}
