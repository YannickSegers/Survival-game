using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	private Rect _textPos;
	private bool _showTextBox;
	private string _message;
	private float _startShowTime = 0.0f;
	private float _duration = 0.0f;

	// Use this for initialization
	void Start () {
		_textPos = new Rect(10,10,200,100);
		_showTextBox = false;
	}

	void Update()
	{
		if(_showTextBox && (Time.time - _startShowTime) >= _duration)
		{
			_showTextBox = false;
			_startShowTime = 0.0f;
			_duration = 0.0f;
		}
	}

	void OnGUI()
	{
		if(_showTextBox)
		{
			GUI.TextArea(_textPos,_message);
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
