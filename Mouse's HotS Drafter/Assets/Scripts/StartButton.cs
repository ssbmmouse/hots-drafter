using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void OnMouseDown() {
        MapDisplay.mapName = Map.theMap.mapName;
        Map.chosenMapID = Map.theMap.mapNum;
        SceneManager.LoadScene(1);
    }
}
