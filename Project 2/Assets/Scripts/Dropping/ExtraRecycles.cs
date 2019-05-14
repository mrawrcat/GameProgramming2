using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraRecycles : MonoBehaviour
{
    public GameObject[] extraRecycle;
    public GameObject[] extraRecycle2;
    public int bleh;
    // Start is called before the first frame update
    void Start()
    {
        
        if(Gamemanager.manager.moreTrash1 == 1)
        {
            for (int i = 0; i < extraRecycle.Length; i++)
            {
                extraRecycle[i].gameObject.transform.position = new Vector2(Random.Range(-9, 9), 30);
            }
        }
        if (Gamemanager.manager.moreTrash2 == 1)
        {
            for (int i = 0; i < extraRecycle2.Length; i++)
            {
                extraRecycle2[i].gameObject.transform.position = new Vector2(Random.Range(-9, 9), 30);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendtomain()
    {
        for (int i = 0; i < extraRecycle.Length; i++)
        {
            extraRecycle[i].gameObject.transform.position = new Vector2(Random.Range(-9, 9), 30);
        }
    }
    public void sendtomain2()
    {
        for (int i = 0; i < extraRecycle2.Length; i++)
        {
            extraRecycle2[i].gameObject.transform.position = new Vector2(Random.Range(-9, 9), 30);
        }
    }
    public void putback()
    {
        for (int i = 0; i < extraRecycle.Length; i++)
        {
            extraRecycle[i].gameObject.transform.position = new Vector2(Random.Range(65, 80), 30);
        }
        for (int i = 0; i < extraRecycle2.Length; i++)
        {
            extraRecycle2[i].gameObject.transform.position = new Vector2(Random.Range(65, 80), 30);
        }
    }
}
