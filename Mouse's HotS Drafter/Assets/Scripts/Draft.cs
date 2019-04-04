using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draft : MonoBehaviour
{
    public GameObject[] bruisers;
    public GameObject[] healers;
    public GameObject[] mAssassins;
    public GameObject[] rAssassins;
    public GameObject[] supports;
    public GameObject[] tanks;

    public Hero[] allHeroes;

    
    public int compType;            // 0 = Dive; 1 = Poke

    public TextMesh compDisplay;    

    public static int phase;

    public static bool firstPick = true;

    public static GameObject[] teamPicks = new GameObject[5];
    public static GameObject[] opponentPicks = new GameObject[5];

    public GameObject[] teamPicksFromEditor;
    public GameObject[] opponentPicksFromEditor;

    public static GameObject[] teamBans = new GameObject[3];
    public static GameObject[] opponentBans = new GameObject[3];

    public GameObject[] teamBansFromEditor;
    public GameObject[] opponentBansFromEditor;

    public static bool setRoles;

    void Start()
    {   
        for (int i = 0; i < teamPicks.Length; i++){
            teamPicks[i] = teamPicksFromEditor[i];
        }
        for (int i = 0; i < opponentPicks.Length; i++){
            opponentPicks[i] = opponentPicksFromEditor[i];
        }
        for (int i = 0; i < teamBans.Length; i++){
            teamBans[i] = teamBansFromEditor[i];
        }
        for (int i = 0; i < opponentBans.Length; i++){
            opponentBans[i] = opponentBansFromEditor[i];
        }
        compType = 0;
        phase = 0;
        FindAllRoles();
    }

    void Update() {
        if (setRoles) {
            FindAllRoles();
            setRoles = false;
        }
        if (compType == 0) {
            compDisplay.text = "Dive Comp";
        } else if (compType == 1) {
            compDisplay.text = "Poke Comp";
        }
    }

    void FindGoodPicks(GameObject[] whichRole, int mode) {
        // Mode determines which role we're looking for
        int j = 0;
        for (int i = 0; i < allHeroes.Length; i++) {    // Cycle through all heroes and determine if they're suitable for the given compType
            if (allHeroes[i].global && !allHeroes[i].picked && !allHeroes[i].banned) {
                if (mode == 0 && allHeroes[i].bruiser || mode == 1 && allHeroes[i].healer || mode == 2 && allHeroes[i].mAssassin || mode == 3 && allHeroes[i].rAssassin || mode == 4 && allHeroes[i].support || mode == 5 && allHeroes[i].tank) {
                    GrabHero(whichRole[j], allHeroes[i].gameObject);
                    j += 1;
                }
            } else if (compType == 0) {
                if (allHeroes[i].diver && !allHeroes[i].picked && !allHeroes[i].banned) {
                    if (mode == 0 && allHeroes[i].bruiser || mode == 1 && allHeroes[i].healer || mode == 2 && allHeroes[i].mAssassin || mode == 3 && allHeroes[i].rAssassin || mode == 4 && allHeroes[i].support || mode == 5 && allHeroes[i].tank) {
                        GrabHero(whichRole[j], allHeroes[i].gameObject);
                        j += 1;
                    }
                }
            } else if (compType == 1) {
                if (allHeroes[i].poker && !allHeroes[i].picked && !allHeroes[i].banned) {
                    if (mode == 0 && allHeroes[i].bruiser || mode == 1 && allHeroes[i].healer || mode == 2 && allHeroes[i].mAssassin || mode == 3 && allHeroes[i].rAssassin || mode == 4 && allHeroes[i].support || mode == 5 && allHeroes[i].tank) {
                        GrabHero(whichRole[j], allHeroes[i].gameObject);
                        j += 1;
                    }
                }
            }
        } 
    }

    void GrabHero(GameObject slot, GameObject hero) {   // Move Hero into slot
        hero.transform.position = slot.transform.position;
        hero.transform.localScale = new Vector3 (0.6f,0.6f,-1f);
    }

    void FindAllRoles() {   // Find heroes which fit the criteria for all roles
        for (int i = 0; i < allHeroes.Length; i++) {    // initialize all hero positions and size to default
            if (!allHeroes[i].picked && !allHeroes[i].banned) {
                allHeroes[i].gameObject.transform.position = allHeroes[i].initPosition;
                allHeroes[i].gameObject.transform.localScale = allHeroes[i].initSize;
            }
        }
        FindGoodPicks(bruisers, 0);
        FindGoodPicks(healers, 1);
        FindGoodPicks(mAssassins, 2);
        FindGoodPicks(rAssassins, 3);
        FindGoodPicks(supports, 4);
        FindGoodPicks(tanks, 5);
    }

    void OnMouseDown() {    // Change the desired criteria on mouse click
        Debug.Log("Clicked!");
        if (compType == 0) {
            compType = 1;
        } else if (compType == 1) {
            compType = 0;
        }
        FindAllRoles();
    }
}
