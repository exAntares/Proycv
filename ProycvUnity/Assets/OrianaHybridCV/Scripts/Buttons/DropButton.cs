using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class DropButton : ButtonBase
{
    [System.Serializable]
    public class DropItemData
    {
        public string ButtonName;
        public GameObject WindowToShow;
    }

    public List<DropItemData> DropItemsData;
    public GameObject DropItemPrefab;

	private float _Height = 4.0f;
	public float Height
	{
		get{ return Selected ? _Height * (_DropItems.Count+1) : _Height;  }
		set{ _Height = value; }
	}

	[HideInInspector]
	public List<DropItem> _DropItems;

    public override void Awake()
    {
        foreach (DropItemData dropItem in DropItemsData)
        {
            GameObject newDropItem = Instantiate(DropItemPrefab) as GameObject;
            newDropItem.transform.parent = transform;
            newDropItem.name = dropItem.ButtonName;

            DropItem DropItemComp = newDropItem.GetComponent<DropItem>();
            DropItemComp.WindowToShow = dropItem.WindowToShow;
        }
    }

	public override void Init()
	{
        ButtonText = gameObject.name;

		base.Init();

		_DropItems = new List<DropItem>();

		DropItem[] Items = GetComponentsInChildren<DropItem>();
		foreach(DropItem Item in Items)
		{
			_DropItems.Add(Item);
			if(Application.isPlaying)
			{
				Item.gameObject.SetActive(false);
			}
		}
	}
	
	public override void OnSelected()
	{
		foreach(DropItem Item in _DropItems)
		{
			Item.gameObject.SetActive(true);
		}

        _DropItems[0].StartSelect();
	}
	
	public override void OnUnSelected()
	{
		foreach(DropItem Item in _DropItems)
		{
			Item.StopSelect();
			Item.gameObject.SetActive(false);
		}
	}

	[ContextMenu("ToggleSelected")]
	void ToggleSelected()
	{
		if(Selected)
		{
			StopSelect();
		}
		else
		{
			UnSelectAllOtherDropButtons();
			StartSelect();
		}
	}

	void OnMouseUpAsButton()
	{
		if(ButtonEnabled)
		{
			ToggleSelected();
            if (ButtonSound)
            {
                AudioSource.PlayClipAtPoint(ButtonSound, Vector3.zero);
            }
		}
	}

	void UnSelectAllOtherDropButtons()
	{
		GameObject[] otherDropButtons = GameObject.FindGameObjectsWithTag("DropButton");
		foreach(GameObject dropbutton in otherDropButtons)
		{
			if(dropbutton != gameObject)
			{
				DropButton DropButtonScript = dropbutton.GetComponent<DropButton>();
				if(DropButtonScript)
				{
					DropButtonScript.StopSelect();
				}
			}
		}
	}

	public void UnSelectAllMyDropItems(DropItem except)
	{
		foreach(DropItem item in _DropItems)
		{
			if(item != except)
			{
				item.StopSelect();
			}
		}
	}

	void FixedUpdate()
	{
		UpdateItemLocations();
	}

	public void UpdateItemLocations()
	{
		float DropItemHeight = 4.0f;
		float AccumulatedHeight = DropItemHeight;
		
		for(int i = 0; i < _DropItems.Count; i++)
		{
			Vector3 newPosition = transform.position;
			
			newPosition.y -= AccumulatedHeight;
			
			_DropItems[i].gameObject.transform.position = newPosition;
			
			AccumulatedHeight += DropItemHeight;
		}
	}
}
