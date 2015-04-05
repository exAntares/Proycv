using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatingReward : MonoBehaviour {

    public Vector3 MouseOffset = new Vector3(2.0f, -2.0f, 0.0f);
    public List<GameObject> InitialObjects = new List<GameObject>();

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform currentchild = transform.GetChild(i);
            currentchild.gameObject.SetActive(false);
            InitialObjects.Add(currentchild.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = transform.position.z;
        transform.position = p + MouseOffset;
    }

    public void ShowInfo(bool show)
    {
        for (int i = 0; i < InitialObjects.Count; ++i)
        {
            InitialObjects[i].SetActive(show);
        }
    }
}
