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

	// Use this for initialization
	void Start () {
		UpdateText();
	}

	public virtual void OnButtonPressed()
	{

	}

	public virtual void OnButtonUnPressed()
	{
	}

	public void StopSelecting()
	{
		Selected = false;

		if(myAnimator)
		{
			myAnimator.Play("Idle");
		}

		OnButtonUnPressed();
	}

	void OnMouseUpAsButton()
	{
		Selected = true;

		if(myAnimator)
		{
			myAnimator.Play("Selected");
		}

		UpdateText();

		OnButtonPressed();
	}

	void OnMouseOver()
	{
		if(myAnimator && !Selected)
		{
			myAnimator.Play("MouseOver");
		}
	}

	void OnMouseExit()
	{
		if(myAnimator && !Selected)
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
