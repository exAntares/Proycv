using UnityEngine;
using System.Collections;

[RequireComponent(typeof (TextMesh))]
[ExecuteInEditMode]
public class TextMeshSortingLayer : MonoBehaviour {
	public string Layer = "GuiText";
    public int index = 0;

	// Use this for initialization
	void Start () {
		renderer.sortingLayerName = Layer;
        renderer.sortingOrder = index;
	}

}
