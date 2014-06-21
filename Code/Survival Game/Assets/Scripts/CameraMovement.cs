using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject _hero;

	private Vector3 _cameraOffset;

	void Start () {
		_cameraOffset = _hero.transform.position -  this.transform.position;
	}

	void LateUpdate () {

		//Check if the camera needs to be turned
		if (Input.GetButtonUp("TurnCameraCW"))
		{
			this.transform.RotateAround(_hero.transform.position,Vector3.up,90);
			_cameraOffset = _hero.transform.position -  this.transform.position;
		}
		
		else if (Input.GetButtonUp("TurnCameraCCW"))
		{
			this.transform.RotateAround(_hero.transform.position,Vector3.up,-90);
			_cameraOffset = _hero.transform.position -  this.transform.position;
		}

		//Set the camera's pos & target
		this.transform.position = _hero.transform.position - _cameraOffset;
		this.transform.LookAt(_hero.transform);
	}
}
