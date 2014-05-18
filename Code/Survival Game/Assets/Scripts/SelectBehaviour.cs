using UnityEngine;
using System.Collections;

public class SelectBehaviour : MonoBehaviour {

	public string _description;
	private UI _uiManager;
	public float _descriptionShowDuration = 5.0f;
	// Use this for initialization
	public virtual void Start () {
		_uiManager = GameObject.Find("UIManager").GetComponent<UI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void SelectObjectPrimary(RaycastHit hit){}
	public virtual void SelectObjectSecondary(RaycastHit hit)
	{
		_uiManager.ShowMessage(_description,_descriptionShowDuration);
	}
}
