using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPickSelector : MonoBehaviour
{
    public bool firstPickSelector;
    public GameObject indicator;

    void OnMouseDown() {
        if (firstPickSelector) {
            Draft.firstPick = true;
        } else {
            Draft.firstPick = false;
        }
        indicator.transform.localPosition = transform.localPosition;
    }
}
