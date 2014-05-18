using UnityEngine;
using System.Collections;

public class MoveToGoalPoint : MonoBehaviour {
	
	private GameObject _goalPoint;
	private float _goalPointOffset = 0.1f;
	
	//Moving
	private Vector3 _direction;
	public float _speed = 3;
	//Turning
	/*private float _turnSpeed = 5;
	private float _rotationMargin = 20;*/
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//_goalPoint = GameObject.FindGameObjectWithTag("GoalPoint");
		if(_goalPoint != null)
		{
			GoToGoalPoint();
		}
	
	}
	
	private void GoToGoalPoint()
	{
		//Calculate direction between Hero & Goalpoint
		float x = _goalPoint.transform.position.x - this.transform.position.x;
		float z = _goalPoint.transform.position.z - this.transform.position.z;
		_direction = new Vector3(x,0,z);
		
		//If hero comes close to goalpoint, goalpoint is destroyed
		if(_direction.magnitude < _goalPointOffset)Destroy(_goalPoint);	
		
		
		//Rotate according to turnSpeed
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (_direction), _turnSpeed * Time.deltaTime);
		
		//if(IsRotationFinished())
		{
			_direction = _direction.normalized;
			this.transform.position += _direction * Time.deltaTime * _speed;
		}
	}
	
	/*private bool IsRotationFinished()
	{
		float currentAngle = transform.rotation.eulerAngles.y;
		float targetAngle = Quaternion.LookRotation (_direction).eulerAngles.y;
		
		float angleDiff = Mathf.DeltaAngle(currentAngle,targetAngle);
		return Mathf.Abs(angleDiff) < _rotationMargin;
	}*/
	
	public GameObject GoalPoint
	{
		get{return _goalPoint;}	
		set{_goalPoint = value;}	
	}
}
