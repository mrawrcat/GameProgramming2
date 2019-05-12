using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicContent : MonoBehaviour
{
    public GameObject content, layout;
    public int buttonNum;
    // Start is called before the first frame update
    void Start()
    {
        buttonNum = layout.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        buttonNum = layout.transform.childCount;

        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, buttonNum * 100);
    }
}
