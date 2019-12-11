using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHandler();
    }

    void movementHandler(){
        if(Input.GetKey(KeyCode.W)){
            this.transform.position = this.transform.position + new Vector3(0f,moveSpeed,0f);
        }

        if(Input.GetKey(KeyCode.A)){
            this.transform.position = this.transform.position + new Vector3(-moveSpeed,0f,0f);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if(Input.GetKey(KeyCode.S)){
            this.transform.position = this.transform.position + new Vector3(0f,-moveSpeed,0f);
        }

        if(Input.GetKey(KeyCode.D)){
            this.transform.position = this.transform.position + new Vector3(moveSpeed,0f,0f);
            this.GetComponent<SpriteRenderer>().flipX = false;

        }
    }
}
