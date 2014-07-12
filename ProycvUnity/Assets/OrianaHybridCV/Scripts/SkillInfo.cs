using UnityEngine;
using System.Collections;

public class SkillInfo : MonoBehaviour {

    public Vector3 MouseOffset = new Vector3( 2.0f, -2.0f, 0.0f);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = transform.position.z;
        transform.position = p + MouseOffset;
	}
}
