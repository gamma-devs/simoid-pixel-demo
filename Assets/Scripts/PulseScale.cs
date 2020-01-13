using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScale : MonoBehaviour
{

    public float pulseStr = 0.1f;
    public float pulseSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().localScale = new Vector3(1,1,1) + new Vector3( Mathf.Sin(Time.time * pulseSpeed) * pulseStr , Mathf.Sin(Time.time * pulseSpeed) * pulseStr , 0 );
    }
}
