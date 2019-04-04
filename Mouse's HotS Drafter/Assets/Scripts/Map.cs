using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map theMap;
    public static Map banOne;
    public static Map banTwo;
    public static int chosenMapID;
    
    SpriteRenderer r;

    public int mapNum;
    public string mapName;

    public static TextMesh phaseDisplay;
    public TextMesh phaseDisplayFromEditor;

    public bool resetter;
    public GameObject startButton;

    void Start()
    {   
        if (resetter) {
            phaseDisplay = phaseDisplayFromEditor;
        }
       
        r = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (banOne && banTwo && theMap && resetter) {
            startButton.SetActive(true);
        } else if (resetter) {
            startButton.SetActive(false);
        }
    }

    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0)) {
            if (!resetter) {
                if (!banOne) {
                    banOne = this;
                    r.color = new Color(0.8f, 0f, 0f, 0.7f);
                    phaseDisplay.text = "Select Ban 2";
                } else if (!banTwo && (this != banOne && this != theMap)) {
                    banTwo = this;
                    r.color = new Color(0.8f, 0f, 0f, 0.7f);
                    phaseDisplay.text = "Select the map to play on";
                } else if (!theMap && (this != banOne && this != banTwo)) {
                    theMap = this;
                    r.color = new Color(0f, 0.8f, 0f, 1f);
                    phaseDisplay.text = "";
                }
            } else {
                Reset();
            }
        }
    }

    void Reset() {
        if (banOne) {
            banOne.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (banTwo) {
            banTwo.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (theMap) {
            theMap.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        banOne = null;
        banTwo = null;
        theMap = null;
        phaseDisplay.text = "Select Ban 1";
    }
}
