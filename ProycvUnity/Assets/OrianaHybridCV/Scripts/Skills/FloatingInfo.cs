﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatingInfo : MonoBehaviour
{
    public Vector3 MouseOffset = new Vector3( 2.0f, -2.0f, 0.0f);
    [HideInInspector]
    public TextMesh TextRenderer;

	// Use this for initialization
	void Start ()
    {
        TextRenderer = GetComponentInChildren<TextMesh>();

        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
	}

    public void SetText(string newText)
    {
        if (TextRenderer)
        {
            TextRenderer.text = newText;
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = transform.position.z;
        transform.position = p + MouseOffset;
	}

    public void ShowInfo(bool show)
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(show);
        }
    }
}
