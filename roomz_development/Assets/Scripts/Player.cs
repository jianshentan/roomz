using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	
	public SwitchCamera cam;
	public float speed;
	public float rotateSpeed;
	
	private enum Axis{
		X,
		Y,
	}
	private Axis axis = Axis.X;
	
	[System.NonSerializedAttribute]
	public bool playerActive = false;
	
	private bool isRotating_Left = false;
	private bool isRotating_Right = false;
	private Quaternion rotate_start;
	private Quaternion rotate_end;
	
	private bool isMoving_Forward = false;
	private bool isMoving_Backward = false;
	private float moving_start_x;
	private float moving_end_x;
	private float moving_start_z;
	private float moving_end_z;
	
	void Update () 
	{	
	// ---this enables continous movement---
	//	if(!isRotating_Left && !isRotating_Right) //-while not rotating
	//	{ 
	//		if(Input.GetKey("up"))
	//		{
	//			gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
	//		}
	//		if(Input.GetKey("down"))
	//		{
	//			gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
	//		}
	//	}
		
	// ---this enables blocky movement---
		if(!playerActive)
		{
			if(Input.GetKeyUp("up"))
			{
				move("forward");
			}
			if(Input.GetKeyUp("down"))
			{
				move("backward");
			}	
		}
		else
		{
			//Debug.LogWarning("Player is currently active! Action cannot be performed when player is active");	
		}
		
		if(!playerActive)
		{
			if(Input.GetKeyUp("space"))
			{
				if(cam.getRotationState() == "left")
					rotate ("left");
				else
					rotate ("right");
			}	
			if(Input.GetKeyUp("left shift"))
			{
				cam.toggleRotationState();
			}
		}
		else
		{
			//Debug.LogWarning("Player is currently active! Action cannot be performed when player is active");	
		}
		
		
		// ---moving---
		if(isMoving_Forward || isMoving_Backward)
		{
			playerActive = true;
			if(isMoving_Forward)
				transform.Translate(-speed*Time.deltaTime, 0, 0);
			else
				transform.Translate(speed*Time.deltaTime, 0, 0);
			moving_end_x = transform.position.x;
			moving_end_z = transform.position.z;
			if(Mathf.Abs(moving_end_x - moving_start_x) > 1 ||
				Mathf.Abs(moving_end_z - moving_start_z) > 1)
			{
				isMoving_Forward = false;
				isMoving_Backward = false;
				playerActive = false;
				correctPosition();
			}
		}
		
		// ---rotating---
		if(isRotating_Left || isRotating_Right)
		{
			playerActive = true;
			if(isRotating_Left)
				transform.Rotate(0,-90f*Time.deltaTime*rotateSpeed,0);
			else
				transform.Rotate(0,90f*Time.deltaTime*rotateSpeed, 0);
			rotate_end = transform.rotation;
			if(Quaternion.Angle(rotate_start, rotate_end) > 90)
			{
				if (isRotating_Left)
					cam.rotateLeft();
				else
					cam.rotateRight();
				
				isRotating_Left = false;
				isRotating_Right = false;
				
				correctPosition();
				
				if(axis == Axis.X)
					axis = Axis.Y;
				else
					axis = Axis.X;
				
				playerActive = false;
			}
		}
	}
	
	bool detect(string direction) 
	{
		Vector3 tempPos = transform.position;
		
		if (direction == "forward" && axis == Axis.X)
			tempPos.x -= 1;
		else if (direction == "forward" && axis == Axis.Y)
			tempPos.z -= 1;
		else if (direction == "backward" && axis == Axis.X)
			tempPos.x += 1;
		else if (direction == "backward" && axis == Axis.Y)
			tempPos.z += 1;
		
		if (Physics.OverlapSphere(tempPos, 0.2f).Length != 0)
			{
				//Debug.Log (Physics.OverlapSphere(tempPos, 0.1f)[0] + " is in the way! You cannot move in that direction");
				return true;
			}
		
		return false;
	}
	
	public void move(string direction)
	{
		if (!detect (direction))
		{
			//Debug.Log (axis);
			if(direction == "forward")
			{
				isMoving_Forward = true;
			}
			else
			{
				isMoving_Backward = true;
			}
			moving_start_x = transform.position.x;
			moving_start_z = transform.position.z;
		}
	}
		
	public void rotate(string direction)
	{
		if(direction == "right")
		{
			isRotating_Right = true;
		}
		else
		{
			isRotating_Left = true;
		}
		rotate_start = transform.rotation;
	}
	
	IEnumerator Rotation (Transform thisTransform, Vector3 degrees, float time) 
	{
	    Quaternion startRotation = thisTransform.rotation;
	    Quaternion endRotation = thisTransform.rotation * Quaternion.Euler(degrees);
	    float rate = 1/time;
	    float t = 0;
	    while (t < 1.0) 
		{
	        t += Time.deltaTime * rate;
	        thisTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
			yield return t; 
   		}
	}
	
	/*
	 * this method sets the position of the player to the center-point of each block and
	 * sets the rotation of the player to round to the closest 90 degrees
	 */
	void correctPosition()
	{
		if (((transform.position.x % 1) != 0) ||
			((transform.position.y % 1) != 0) ||
			((transform.position.z % 1) != 0))
			transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
		
		if ((transform.rotation.eulerAngles.y > 315f && transform.rotation.eulerAngles.y < 360f) ||
			(transform.rotation.eulerAngles.y > 0f && transform.rotation.eulerAngles.y < 45f))
			transform.eulerAngles = new Vector3(0,0,0);
		else if (transform.rotation.eulerAngles.y > 45f && transform.rotation.eulerAngles.y < 135f)
			transform.eulerAngles = new Vector3(0,90,0);
		else if (transform.rotation.eulerAngles.y > 135f && transform.rotation.eulerAngles.y < 225f)
			transform.eulerAngles = new Vector3(0,180,0);
		else if (transform.rotation.eulerAngles.y > 225f && transform.rotation.eulerAngles.y < 315f)
			transform.eulerAngles = new Vector3(0,270,0);
		
	}
	
	public void setPlayerActive(bool flag)
	{
		playerActive = flag;
	}
	
	public bool getPlayerActive()
	{
		return playerActive;	
	}
}
