using UnityEngine;
using System.Collections;

public class SBFloor : SelectBehaviour {

	public GameObject _goalPoint;
	public GameObject _hero;
	private MoveToGoalPoint _heroMovement = null;

	// Use this for initialization
	public override void Start () {
		base.Start();
		if(_hero != null) // Retrieve the hero movement script
		{
			_heroMovement = _hero.GetComponent<MoveToGoalPoint>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void SelectObjectPrimary(RaycastHit hit)
	{
		//Creates a goalpoint and makes the hero move to it
		//Destoy the original goalpoint
		if(_heroMovement.GoalPoint != null)
		{
			Destroy(_heroMovement.GoalPoint);	
		}
		
		Vector3 pos = hit.point;
		GameObject currGoalPoint = Instantiate(_goalPoint,pos,Quaternion.identity) as GameObject;
		
		_heroMovement.GoalPoint = currGoalPoint;
	}
}
