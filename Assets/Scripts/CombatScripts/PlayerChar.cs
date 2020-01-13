using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour
{

    public GameObject healthBar;
    public GameObject manaBar;
    public GameObject actionBar;
    public GameObject healthText;
    public GameObject manaText;
    public GameObject gameHandlerObject;
    public int playerID;
    GameHandler gameHandler;

    float maxHP;
    float currentHP;
    float maxMP;
    float currentMP;
    float maxAP;
    float currentAP;
    float pulseMod;

    bool actionFull;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = gameHandlerObject.GetComponent<GameHandler>();
        setVerticalBar(actionBar,0.0f);
        maxAP = 2;
        actionFull = false;
        pulseMod = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAP < maxAP){
            currentAP += Time.deltaTime;
        }
        
        // Cap maxAP
        if(currentAP > maxAP){
            currentAP = maxAP;
            actionFull = true;
            gameHandler.pushToPlayerOrder(playerID);
        }
        
        // Pulse actionBar when full
        if(actionFull){
            actionBar.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1) * (1-pulseMod)+  new Color(1,1,1,1) * Mathf.Abs(Mathf.Sin(Time.time*1.5f)) * pulseMod;                              
        }
        
        setVerticalBar(actionBar,currentAP/maxAP);
    }

    // Action bar
    void setVerticalBar(GameObject bar, float value){
        bar.transform.localScale = new Vector3(1,value,1);
    }

    // Health and mana
    void setHorizontalBar(GameObject bar, float value){
        bar.transform.localScale = new Vector3(value,1,1);
    }

    public void emptyActionBar(){
        currentAP = 0;
    }
}
