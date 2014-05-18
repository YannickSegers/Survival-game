using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) //left or right click
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, Mathf.Infinity))
			{				
				GameObject hitObject = hit.collider.gameObject;
				if(hitObject != null)
				{
					//Call the selected function of the selected object
					SelectBehaviour selectBehaviour = hitObject.GetComponent<SelectBehaviour>();
					if(selectBehaviour != null)
					{
						if(Input.GetMouseButtonDown(0))// on left click, call selectObjectPrimary
						{
							selectBehaviour.SelectObjectPrimary(hit);
						} else if(Input.GetMouseButtonDown(1))// on left click, call selectObjectSecondary
						{
							selectBehaviour.SelectObjectSecondary(hit);
						}
					}
						
				}
			}
		}
	}
}
