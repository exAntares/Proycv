using UnityEngine;
using System.Collections;

public class MailBoxButton : ButtonBase
{
	public GameObject ContactCard;

	public override void OnSelected()
	{
		if(ContactCard)
		{
			Animator ContactCardAnim = ContactCard.GetComponent<Animator>();
			if(ContactCardAnim)
			{
				ContactCardAnim.Play("Show");
			}
		}
	}
	
	public override void OnUnSelected()
	{
	}
}
