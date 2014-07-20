using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TabButton : ButtonBase
{
	public bool DefaultTab = false;
	public GameObject AssociatedTab;
	
	public override void Init()
	{
		base.Init();

		if(DefaultTab)
		{
			StartSelect();
		}
	}

	public override void OnSelected()
	{
		SelectTab();
	}
	
	public override void OnUnSelected()
	{
		UnSelectTab();
	}
	
	public void SelectTab()
	{
		UnSelectAllTabs();

		if(AssociatedTab && !AssociatedTab.activeSelf)
		{
			AssociatedTab.SetActive(true);
		}
	}

	public void UnSelectTab()
	{
		if(AssociatedTab && AssociatedTab.activeSelf)
		{
			AssociatedTab.SetActive(false);
		}
	}

	public void UnSelectAllTabs()
	{
		GameObject[] tabs = GameObject.FindGameObjectsWithTag("TabButton");
		foreach(GameObject tab in tabs)
		{
			TabButton TabScript = tab.GetComponent<TabButton>();
			if(TabScript && TabScript != this)
			{
				TabScript.StopSelect();
			}
		}
	}

}
