using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ExperienceSubWindow : MonoBehaviour {

	[Multiline]
	public string WindowText = "Insert Text";
	public TextMesh TextMeshRenderer;

	// Use this for initialization
	void Start () {
	
		if(TextMeshRenderer)
		{
			TextMeshRenderer.text = WindowText;
		}
	}

}
