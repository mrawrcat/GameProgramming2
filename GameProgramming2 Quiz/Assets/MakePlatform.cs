using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlatform : MonoBehaviour
{
    public GameObject platform_prefab;
    public float timer = 0, targetTime;
   
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > targetTime)
        {
            GameObject p;

            //make platform at this location
            p = Instantiate(platform_prefab, new Vector2(7, Random.Range(-5, 5)), Quaternion.identity);

            //how big platforms are
            p.transform.localScale = new Vector2(Random.Range(3,5), 0.3f);
            timer = 0;
        }

    }
}
