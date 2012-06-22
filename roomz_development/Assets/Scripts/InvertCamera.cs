using UnityEngine;
using System.Collections;

public class InvertCamera : MonoBehaviour {
	// ** for some reason, inverting the camera requires the camera to have a closer relative position to the player
	// instead of putting it one unit away, it needs to be 0.5 units away
	
	public Camera invertCamera;
	public float inversion; //this should be -1
	
	void Start () {
		Matrix4x4 mat = invertCamera.projectionMatrix;
		mat *= Matrix4x4.Scale(new Vector3(inversion, 1, 1));
		invertCamera.projectionMatrix = mat;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
