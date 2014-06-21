using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	private Camera _camera;

	void Start ()
	{
		//Find camera and set it
		_camera = Camera.main;

		//If no camera is found, generate warning
		if (_camera == null)
			Debug.Log("Camera variable is null!");

	}

	void Update ()
	{
		Vector3 target = new Vector3(_camera.transform.position.x,this.transform.position.y,_camera.transform.position.z);

		transform.LookAt(target);
		transform.Rotate(Vector3.up,180);
	}
}