using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CombatClasses;

public class GameHandler : MonoBehaviour
{
    public GameObject leftBar;
    public GameObject playersParent;
    Vector3 leftBarOriginalPos;
    List<int> playerOrder;
    List<CombatAction> actionStack;
    // Start is called before the first frame update
    void Start()
    {
        leftBarOriginalPos = leftBar.transform.position;
        playerOrder = new List<int>();
        leftBar.transform.Translate(new Vector3(-2f,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        foreach(int playerID in playerOrder){
            Debug.Log(playerID);
        }

        if(playerOrder.Count == 0){
            if(leftBar.transform.position.x > -11f){
                leftBar.transform.Translate(new Vector3(-0.15f,0,0));
            }
        }else{
            if(leftBar.transform.position.x < leftBarOriginalPos.x){
                leftBar.transform.Translate(new Vector3(0.15f,0,0));
            }
            if(leftBar.transform.position.x > leftBarOriginalPos.x){
                leftBar.transform.position = leftBarOriginalPos;
            }
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            foreach(Transform child in playersParent.transform){
                playerOrder.Clear();
                child.gameObject.GetComponent<PlayerChar>().emptyActionBar();
            }
        }
    }

    public void pushToPlayerOrder(int playerID){
        playerOrder.Add(playerID);
    }

    public void pushToCombatStack(CombatAction action){
        actionStack.Add(action);
        return;
    }
}
