using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DropButtonManager : MonoBehaviour {

	public List<DropButton> DropButtons;
	private float AccumulatedHeight;
	// Update is called once per frame
	void FixedUpdate () {

		UpdateLocations();

	}

	[ContextMenu("UpdateLocations")]
	void UpdateLocations()
	{
		AccumulatedHeight = 0.0f;
		
		for(int i = 0; i < DropButtons.Count; i++)
		{
			Vector3 newPosition = transform.position;
			
			newPosition.y += AccumulatedHeight;
			
			DropButtons[i].gameObject.transform.position = newPosition;
			DropButtons[i].UpdateItemLocations();
			
			AccumulatedHeight -= GetButtonHeight(DropButtons[i]);
		}
	}

	public float GetButtonHeight(DropButton Button)
	{
		return Button.Height;
	}
}
