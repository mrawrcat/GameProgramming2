using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] bgs;
    private float[] parallaxScales;
    public float smoothing;
    private Vector3 prevCamPos;
    // Start is called before the first frame update
    void Start()
    {
        prevCamPos = transform.position;
        parallaxScales = new float[bgs.Length];
        for(int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = bgs[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0; i < bgs.Length; i++)
        {
            Vector3 parallax = (prevCamPos - transform.position) * (parallaxScales[i] / smoothing);
            bgs[i].position = new Vector3(bgs[i].position.x + parallax.x, bgs[i].position.y + parallax.y, bgs[i].position.z);
            prevCamPos = transform.position;
        }
    }
}
