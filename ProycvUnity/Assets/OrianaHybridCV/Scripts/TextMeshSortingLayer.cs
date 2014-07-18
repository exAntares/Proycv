using UnityEngine;
using System.Collections;

[RequireComponent(typeof (TextMesh))]
[ExecuteInEditMode]
public class TextMeshSortingLayer : MonoBehaviour {
	public string Layer = "GuiText";

	// Use this for initialization
	void Start () {
		renderer.sortingLayerName = Layer;
	}

}
