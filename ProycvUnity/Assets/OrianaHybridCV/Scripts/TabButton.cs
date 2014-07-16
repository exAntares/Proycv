using UnityEngine;
using System.Collections;

public class TabButton : MonoBehaviour {

	public bool DefaultTab = false;
	public string TabDisplayName = "";
	public Animator myAnimator;
	public TextMesh TabTextRenderer;
	public GameObject AssociatedTab;

	public Color NormalColor = Color.gray;
	public Color SelectedColor = Color.yellow;


	protected bool Selected;

	void Start()
	{
		if(DefaultTab)
		{
			SelectTab();
		}

		UpdateTabName();
	}

	void UpdateTabName()
	{
		if(TabTextRenderer)
		{
			TabTextRenderer.text = GetTabName();
		}
	}

	string GetTabName()
	{
		string End = "</color>";
		string Start = Selected ? "<color=#"+RGBToHex(SelectedColor)+">" : "<color=#"+RGBToHex(NormalColor)+">";
		return Start + TabDisplayName + End;
	}

	string GetHex(int myDecimal)
	{
		string alpha = "0123456789ABCDEF";
		string HexName = "" + alpha[myDecimal];
		return HexName;
	}

	string RGBToHex(Color ColorToHex)
	{
		float red = ColorToHex.r * 255;
		float green = ColorToHex.g * 255;
		float blue = ColorToHex.b * 255;
		
		string r1 = GetHex((int)Mathf.Floor(red / 16));
		string r2 = GetHex((int)Mathf.Floor(red % 16));
		string g1 = GetHex((int)Mathf.Floor(green / 16));
		string g2 = GetHex((int)Mathf.Floor(green % 16));
		string b1 = GetHex((int)Mathf.Floor(blue / 16));
		string b2 = GetHex((int)Mathf.Floor(blue % 16));
		
		string z = r1 + r2 + g1 + g2 + b1 + b2;
		
		return z;
	}

	void OnMouseUpAsButton()
	{
		SelectTab();
	}

	public void SelectTab()
	{
		UnSelectAllTabs();

		Selected = true;

		if(myAnimator)
		{
			myAnimator.Play("Selected");
		}

		if(AssociatedTab && !AssociatedTab.activeSelf)
		{
			AssociatedTab.SetActive(true);
		}

		UpdateTabName();
	}

	public void UnSelectTab()
	{
		Selected = false;

		if(myAnimator)
		{
			myAnimator.Play("UnSelected");
		}

		if(AssociatedTab && AssociatedTab.activeSelf)
		{
			AssociatedTab.SetActive(false);
		}

		UpdateTabName();
	}

	public void UnSelectAllTabs()
	{
		GameObject[] tabs = GameObject.FindGameObjectsWithTag("TabButton");
		foreach(GameObject tab in tabs)
		{
			TabButton TabScript = tab.GetComponent<TabButton>();
			if(TabScript && TabScript != this)
			{
				TabScript.UnSelectTab();
			}
		}
	}

}
