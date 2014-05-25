using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour {

	private Rect _textPos;
	private bool _showTextBox;
	private string _message;
	private float _startShowTime = 0.0f;
	private float _duration = 0.0f;
	private bool _showInventory = true;

	public GameObject _hero;
	private Inventory _heroInventory;
	private List<Rect> _hotKeyPos;

	// Use this for initialization
	void Start () 
	{
		_textPos = new Rect(10,10,200,100);
		_showTextBox = false;

		if(_hero != null) // Retrieve the hero Inventory
		{
			_heroInventory = _hero.GetComponent<Inventory>();
		}

		//Calculate the hotKeyList rects
		_hotKeyPos = new List<Rect>();
		int xStartPos = (Screen.width/2 - (50 * (_heroInventory.HotKeyCapacity/2)));
		int yStartPos = Screen.height - 55;
		for(int i = 0; i < _heroInventory.HotKeyCapacity; ++i)
		{
			int x;
			x = xStartPos + 50*i;
			_hotKeyPos.Add(new Rect(x,yStartPos,50,50));
		}
	}

	void Update()
	{
		if(_showTextBox && (Time.time - _startShowTime) >= _duration)
		{
			_showTextBox = false;
			_startShowTime = 0.0f;
			_duration = 0.0f;
		}

		if(Input.GetKeyUp(KeyCode.I))
		{
			_showInventory = !_showInventory;
		}
	}

	void OnGUI()
	{
		if(_showTextBox)
		{
			GUI.Box(_textPos,_message);
		}

		if(_showInventory)
		{
			for(int i = 0; i < _heroInventory.HotKeyCapacity; ++i)
			{
				string itemText = "";
				if(_heroInventory.GetItem(i) != null)
				{
					itemText = "Item " + _heroInventory.GetItem(i).Type;
				} else
				{
					itemText = "None";
				}
				GUI.Box(_hotKeyPos[i],itemText);
			}
		}
	}

	public void ShowMessage(string message, float duration)
	{
		_message = message;
		_duration = duration;
		_startShowTime = Time.time;
		_showTextBox = true;
	}
}
