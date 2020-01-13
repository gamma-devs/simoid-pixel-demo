using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBob : MonoBehaviour
{
    Vector3 OriginalPos;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,Mathf.Sin(Time.time*10)* 0.005f,0));
    }
}
