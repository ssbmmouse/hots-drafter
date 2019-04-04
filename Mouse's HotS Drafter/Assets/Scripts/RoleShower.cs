using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleShower : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] roles;
    Vector3[] initPositions = new Vector3[6];
    public static bool[] toggles = new bool[6];

    public static bool setToggled;

    void Awake() {
        for (int i = 0; i < roles.Length; i++) {
            initPositions[i] = roles[i].transform.position;
        }
    }

    void Start() {
        for (int i = 0; i < toggles.Length; i++) {
            toggles[i] = true;
        }
        SetToggled();
    }

    void Update() {
        if (setToggled) {
            SetToggled();
            setToggled = false;
        }
    }
    void SetToggled() {
        int j = 5;
        for (int i = 5; i >= 0; i--) {
            if (toggles[i]) {
                roles[i].gameObject.transform.position = slots[j].gameObject.transform.position;
                j -= 1;
            } else {
                roles[i].gameObject.transform.position = initPositions[i];
            }
        }
        Draft.setRoles = true;
    }
}
