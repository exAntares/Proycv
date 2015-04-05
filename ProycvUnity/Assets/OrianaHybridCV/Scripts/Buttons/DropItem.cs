using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DropItem : ButtonBase
{
	public GameObject WindowToShow;
	private DropButton Owner;

	public override void Init()
	{
		ButtonText = gameObject.name;
		base.Init();
		Owner = transform.parent ? transform.parent.GetComponent<DropButton>() : null;
	}

	public override void OnSelected()
	{
        if (Owner)
        {
            Owner.UnSelectAllMyDropItems(this);
        }

		if(WindowToShow)
		{
			WindowToShow.SetActive(true);
		}
	}
	
	public override void OnUnSelected()
	{
		if(WindowToShow)
		{
			WindowToShow.SetActive(false);
		}
	}
}
