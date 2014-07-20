using UnityEngine;
using System.Collections;

public class ButtonBase : MonoBehaviour
{
	public string ButtonText = "";

	public TextMesh TextRenderer;
	public Animator myAnimator;

	public Color TextNormalColor = Color.yellow;
	public Color TextSelectedColor = Color.white;

	protected bool Selected = false;
	protected bool ButtonEnabled = true;

	public void DisableButton()
	{
		ButtonEnabled = false;
	}

	public void EnableButton()
	{
		ButtonEnabled = true;
	}

	// Use this for initialization
	void Start ()
	{
		Init();
	}

	public virtual void Init()
	{
		UpdateText();
	}

	public virtual void OnSelected()
	{

	}

	public virtual void OnUnSelected()
	{
	}

	public void StopSelect()
	{
		Selected = false;

		if(myAnimator)
		{
			myAnimator.Play("Idle");
		}

		UpdateText();

		OnUnSelected();
	}

	public void StartSelect()
	{
		Selected = true;
		
		if(myAnimator)
		{
			myAnimator.Play("Selected");
		}
		
		UpdateText();
		
		OnSelected();
	}

	void OnMouseUpAsButton()
	{
		if(ButtonEnabled)
		{
			StartSelect();
		}
	}

	void OnMouseOver()
	{
		if(ButtonEnabled && myAnimator && !Selected)
		{
			myAnimator.Play("MouseOver");
		}

		UpdateText();
	}

	void OnMouseExit()
	{
		if(ButtonEnabled && myAnimator && !Selected)
		{
			myAnimator.Play("Idle");
		}

		UpdateText();
	}
	
	public void UpdateText()
	{
		if(TextRenderer)
		{
			TextRenderer.text = GetButtonText();
		}
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

	string GetButtonText()
	{
		string End = "</color>";
		string Start = Selected ? "<color=#"+RGBToHex(TextSelectedColor)+">" : "<color=#"+RGBToHex(TextNormalColor)+">";
		return Start + ButtonText + End;
	}

}
