using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : MonoBehaviour
{   
    public int mode;
    SpriteRenderer r;

    void Start() {
        r = GetComponent<SpriteRenderer>();
    }
    void OnMouseDown()
    {
        if (RoleShower.toggles[mode] == false) {
                RoleShower.toggles[mode] = true;
                r.color = new Color(1,1,1,1);
                
        } else {
            RoleShower.toggles[mode] = false;
            r.color = new Color(0.5f,0.5f,0.5f,0.5f);
        }
       RoleShower.setToggled = true;
       Draft.setRoles = true;
    }
}
