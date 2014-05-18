using UnityEngine;
using System.Collections;

public class GoalPointBehaviour : MonoBehaviour {
	
	public ParticleSystem _particleEffect;
	
	// Use this for initialization
	void Start () {
		//this.transform.Rotate(-90,0,0);
		Instantiate(_particleEffect, this.transform.position, this.transform.rotation);
		//this.renderer.enabled = false;
	
	}
}
