using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public static string mapName;
    public TextMesh mapText;
    public Sprite[] maps;

    void Start()
    {   
        GetComponent<SpriteRenderer>().sprite = maps[Map.chosenMapID];
        mapText.text = mapName;
    }

}
