using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseDisplayer : MonoBehaviour
{
    public TextMesh theText;
    void Update()
    {
        if (Draft.phase < 4) {
            theText.text = "Ban a Hero";
        }  else if (Draft.phase >= 4 && Draft.phase < 9) {
            theText.text = "Pick a Hero";
        }  else if (Draft.phase >= 9 && Draft.phase < 11) {
            theText.text = "Ban a Hero";
        } else if (Draft.phase >= 11 && Draft.phase < 16) {
            theText.text = "Pick a Hero";
        } else {
            theText.text = "glhf!";
        }
    }
}
