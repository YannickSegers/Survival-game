using UnityEngine;
using System.Collections;

public class SBTree : SelectBehaviour {

	public GameObject _goalPoint;
	public GameObject _hero;
	public float _minDist = 1.0f;
	private MoveToGoalPoint _heroMovement = null;
	private Inventory _heroInventory;


	// Use this for initialization
	public override void Start () {
		base.Start();

		if(_hero != null) // Retrieve the hero movement script
		{
			_heroInventory = _hero.GetComponent<Inventory>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void SelectObjectPrimary(RaycastHit hit)
	{
		//Checks if there is an axe in the inventory
		if(_heroInventory.IsItemActive(ItemType.Axe))
		{
			Vector2 treePos;
			treePos.x = _hero.transform.position.x;
			treePos.y = _hero.transform.position.z;

			Vector2 heroPos;
			heroPos.x = transform.position.x;
			heroPos.y = transform.position.z;

			Vector2 distance = treePos - heroPos;
			//If the tree is too far away, walk over there
			if(distance.sqrMagnitude >= _minDist)
			{
				if(_heroMovement.GoalPoint != null)
				{
					Destroy(_heroMovement.GoalPoint);	
				}
				
				Vector3 pos = hit.point;
				GameObject currGoalPoint = Instantiate(_goalPoint,pos,Quaternion.identity) as GameObject;
				
				_heroMovement.GoalPoint = currGoalPoint;
			} else // Cut the tree
			{

			}
		} else 
		{	//If no axe is selected, show the description
			SelectObjectSecondary(hit);
		}
	}
}
