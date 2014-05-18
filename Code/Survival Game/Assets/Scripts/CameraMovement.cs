using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject _hero;

	private Vector3 _cameraOffset;

	// Use this for initialization
	void Start () {
		_cameraOffset = _hero.transform.position -  this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = _hero.transform.position - _cameraOffset;
	}
}
