using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CombatClasses;

public class MenuNavigation : MonoBehaviour
{ 

    public GameObject LeftBar;
    public GameHandler gameHandler;
    float pulseStr = 0.2f;
    float pulseSpeed = 3f;
    enum leftBarSelections {Attack, Defend, Magic, Item, Run, Wait};
    int totalSelections = 6;
    int currentSelection = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = gameObject.GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {   
        InputHandler();
        SelectionPulse();
    }

    
    void InputHandler(){
        // Handle input for navigating the left bar
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            foreach (Transform child in LeftBar.transform.GetChild(currentSelection)){
                child.localScale = new Vector3(1,1,1); 
            }
            if(currentSelection >= totalSelections-1){
                currentSelection = 0;
            }else{
                currentSelection++;
            }
        }else if(Input.GetKeyDown(KeyCode.UpArrow)){
            foreach (Transform child in LeftBar.transform.GetChild(currentSelection)){
                child.localScale = new Vector3(1,1,1); 
            }
            if(currentSelection < 1){
                currentSelection = 5;
            }else{
                currentSelection--;
            }
        }

        // DEBUG add action to action stack
        if(Input.GetKeyDown(KeyCode.Z) && currentSelection == 0){
            CombatAction newAction = new CombatAction();
            newAction.name = "Debug Attack";
            newAction.damage = 1;
            newAction.sourceID = 0;
            newAction.targetID = 0;
            gameHandler.pushToCombatStack(newAction);
        }
    }

    // Make the selected box in left bar pulse 
    void SelectionPulse(){
        foreach (Transform child in LeftBar.transform.GetChild(currentSelection)){
            child.localScale = new Vector3(1,1,1) + new Vector3( Mathf.Sin(Time.time * pulseSpeed) * pulseStr , Mathf.Sin(Time.time * pulseSpeed) * pulseStr , 0 ); 
        }
    }
}
