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
        actionStack = new List<CombatAction>();
        leftBar.transform.Translate(new Vector3(-2f,0,0));
    }

    // Update is called once per frame
    void Update()
    {

        // Handle left bar hide/show
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

        // DEBUG RESET ALL ACTION BARS
        if(Input.GetKeyDown(KeyCode.Q)){
            foreach(Transform child in playersParent.transform){
                playerOrder.Clear();
                child.gameObject.GetComponent<PlayerChar>().emptyActionBar();
            }
        }
        
    }

    // Push player ID to the player order stack.
    public void pushToPlayerOrder(int playerID){
        playerOrder.Add(playerID);
    }

    // Push an CombatAction ot the stack
    public void pushToCombatStack(CombatAction action){
        Debug.Log(action.name);
        actionStack.Add(action);
    }

    // Perform the action
    public void doAction(int playerID){
        return;
    }
}
