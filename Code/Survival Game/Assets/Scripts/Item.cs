using UnityEngine;
using System.Collections;
using System;

public enum ItemType
{
	None,
	Axe,
	Apple,
};

public class Item : MonoBehaviour, IEquatable<Item> {

	public int _maxStackCapacity = 20;
	private int _stackSize = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Adds the specified number of items to this stack
	//If the stack would grow bigger than the maxStack number, returns the remaining items that didnt get added. 0 if there is no rest.
	public int AddToStack(int pNumToAdd)
	{
		_stackSize += pNumToAdd;
		int rest = 0;
		if(_stackSize > _maxStackCapacity)
		{
			rest = _stackSize - _maxStackCapacity;
			_stackSize = _maxStackCapacity;
		}
		return rest;
	}

	public int StackSize
	{
		get {return _stackSize;}
	}

	public ItemType Type
	{
		get;
		set;
	}

	public override bool Equals(object obj)
	{
		if (obj == null) return false;
		Item objAsItem = obj as Item;
		if (objAsItem == null) return false;
		else return Equals(objAsItem);
	}

	public bool Equals(Item other)
	{
		if (other == null) return false;
		return (this.Type.Equals(other.Type));
	}
}
