using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public 	int 			_inventoryCapacity = 20;
	public 	int 			_hotKeyCapacity = 10;
	private List<Item> 		_inventoryList = null;
	private List<Item> 		_hotKeyList = null;
	private Item 			_ActiveItem = null;

	// Use this for initialization
	void Start () {
		_inventoryList = new List<Item>(_inventoryCapacity);
		_hotKeyList = new List<Item>(_hotKeyCapacity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddItemToInventory(Item pItem)
	{
		int rest = -1;
		if(_hotKeyList.Contains(pItem)) //If the item is already in the hotkeylist, add it to it
		{
			int index = _hotKeyList.IndexOf(pItem);
			rest = _hotKeyList[index].AddToStack(pItem.StackSize);
			//If there is rest, check to see if there is another instance of this item in the hotKeyList
			while(rest > 0 && index != -1)
			{
				index = _hotKeyList.IndexOf(pItem,index+1);
				if(index != -1)
				{
					rest = _hotKeyList[index].AddToStack(pItem.StackSize);
				}
			}
		}

		if(_inventoryList.Contains(pItem) && rest != 0) //If the item was not in the hotKeylist, or there is still rest and it is already in the inventory list, add it to the stack
		{
			int index = _inventoryList.IndexOf(pItem);
			rest = _inventoryList[index].AddToStack(pItem.StackSize);

			//If there is rest, check to see if there is another instance of this item in the inventoryList, if so add it to that
			while(rest > 0 && index != -1)
			{
				index = _inventoryList.IndexOf(pItem,index+1);
				if(index != -1)
				{
					rest = _inventoryList[index].AddToStack(pItem.StackSize);
				}
			}
		}

		if(rest != 0) //If the item was not yet in the list, or there still is rest, add it to a new position in the list.
		{
			//If there is still room in the hotkeyList, add it there
			if(_hotKeyList.Count < _hotKeyCapacity)
			{
				_hotKeyList.Add(pItem);
			} else if (_inventoryList.Count < _inventoryCapacity) //If there is no room in the hotkeyList, but there is still room in the inventory, add it to the inventory
			{
				_inventoryList.Add(pItem);
			} else // There is no room in the inventory, show message that the item cannot be added to the inventory.
			{

			}
		}
	}

	//Indices include hotKeyCapacity: everything in the inventoryList has index: inventoryList index + hotKeyCapacity
	public void SwitchItems(int pFromIndex, int pToIndex)
	{
		//Determine from which list to which list the items have to be switched
		List<Item> fromList;
		List<Item> toList;
		int realFromIndex, realToIndex;
		if(pFromIndex < _hotKeyCapacity) // the from Item is from the hotkeylist
		{
			fromList = _hotKeyList;
			realFromIndex = pFromIndex;
		} else{ // the from Item is from the inventoryList
			fromList = _inventoryList;
			realFromIndex = pFromIndex - _hotKeyCapacity;
		}

		if(pToIndex < _hotKeyCapacity) // the to Item is from the hotkeylist
		{
			toList = _hotKeyList;
			realToIndex = pToIndex;
		} else{ // the to Item is from the inventoryList
			toList = _inventoryList;
			realToIndex = pToIndex - _hotKeyCapacity;
		}

		//Switch the items around
		Item fromItem = fromList[realFromIndex];
		fromList[realFromIndex] = toList[realToIndex];
		toList[realToIndex] = fromItem;
	}

	public bool HasItem(Item pItem)
	{
		return (_hotKeyList.Contains(pItem) || _inventoryList.Contains(pItem));
	}

	public bool HasItem(ItemType pType)
	{
		return (_hotKeyList.Contains(new Item(){Type = pType}) || _inventoryList.Contains(new Item(){Type = pType}));
	}

	public void DropItem(int pIndex)
	{
		if(pIndex < _hotKeyCapacity) // the item is from the hotkeylist
		{
			//_hotKeyList[pIndex] = new Item();
			_hotKeyList.RemoveAt(pIndex);
		} else{ // the item is from the inventoryList
			_inventoryList[pIndex - _hotKeyCapacity] = new Item();
		}
	}

	public Item ActiveItem
	{
		get {return _ActiveItem;}
		set {_ActiveItem = value;}
	}

	public bool IsItemActive(ItemType pType)
	{
		return _ActiveItem.Type == pType;
	}

	public int HotKeyCapacity
	{
		get{ return _hotKeyCapacity;}
	}

	public Item GetItem(int pIndex)
	{
		if(pIndex < _hotKeyCapacity)
		{
			if(pIndex >= _hotKeyList.Count)
			{
				return null;
			} else
			{
				return _hotKeyList[pIndex];
			}
		} else 
		{
			if(pIndex >= _inventoryList.Count)
			{
				return null;
			} else
			{
				return _inventoryList[pIndex - _hotKeyCapacity];
			}
		}
	}
}
