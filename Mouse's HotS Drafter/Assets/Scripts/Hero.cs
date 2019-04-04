using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour // Class which contains information about each Hero
{
    public string heroName;     // Name
    public bool bruiser;        // HERO ROLES (set in editor)
    public bool healer;
    public bool mAssassin;
    public bool rAssassin;
    public bool support;
    public bool tank;           
                                // HERO COMPS
    public bool global;
    public bool diver;
    public bool poker;

    // ETC
    public bool banned;
    public bool picked;

    public Vector3 initPosition;
    public Vector3 initSize;

    void Awake() {
        initPosition = transform.position;
        initSize = transform.localScale;
        banned = false;
        picked = false;
    }

    void Start() {
        banned = false;
        picked = false;
    }

    void OnMouseDown() {
        // BAN 1
        if (!picked && !banned) {
            if (Draft.phase == 0) {
                if (Draft.firstPick) {
                    SetTeamBan(0);
                } else {
                    SetOpponentBan(0);
                }
            }
            // BAN 2
            else if (Draft.phase == 1) {
                if (Draft.firstPick) {
                    SetOpponentBan(0);
                } else {
                    SetTeamBan(0);
                }
            }
            // BAN 3
            else if (Draft.phase == 2) {
                if (Draft.firstPick) {
                    SetTeamBan(1);
                } else {
                    SetOpponentBan(1);
                }
            }
            // BAN 4
            else if (Draft.phase == 3) {
                if (Draft.firstPick) {
                    SetOpponentBan(1);
                } else {
                    SetTeamBan(1);
                }
            }
            // PICK 1
            else if (Draft.phase == 4) {
                if (Draft.firstPick) {
                    SetTeamPick(0);
                } else {
                    SetOpponentPick(0);
                }
            }
            // PICK 2 && 3
            else if (Draft.phase == 5) {
                if (Draft.firstPick) {
                    SetOpponentPick(0);
                } else {
                    SetTeamPick(0);
                }
            }
            else if (Draft.phase == 6) {
                if (Draft.firstPick) {
                    SetOpponentPick(1);
                } else {
                    SetTeamPick(1);
                }
            }
            // PICK 4 && 5
            else if (Draft.phase == 7) {
                if (Draft.firstPick) {
                    SetTeamPick(1);
                } else {
                    SetOpponentPick(1);
                }
            }
            else if (Draft.phase == 8) {
                if (Draft.firstPick) {
                    SetTeamPick(2);
                } else {
                    SetOpponentPick(2);
                }
            }
            // BAN 5
            else if (Draft.phase == 9) {
                if (Draft.firstPick) {
                    SetOpponentBan(2);
                } else {
                    SetTeamBan(2);
                }
            }
            // BAN 6
            else if (Draft.phase == 10) {
                if (Draft.firstPick) {
                    SetTeamBan(2);
                } else {
                    SetOpponentBan(2);
                }
            }
            // PICK 6 && 7
            else if (Draft.phase == 11) {
                if (Draft.firstPick) {
                    SetOpponentPick(2);
                } else {
                    SetTeamPick(2);
                }
            }
            else if (Draft.phase == 12) {
                if (Draft.firstPick) {
                    SetOpponentPick(3);
                } else {
                    SetTeamPick(3);
                }
            }
            // PICK 8 && 9
            else if (Draft.phase == 13) {
                if (Draft.firstPick) {
                    SetTeamPick(3);
                } else {
                    SetOpponentPick(3);
                }
            }
            else if (Draft.phase == 14) {
                if (Draft.firstPick) {
                    SetTeamPick(4);
                } else {
                    SetOpponentPick(4);
                }
            }

            // PICK 10
            else if (Draft.phase == 15) {
                if (Draft.firstPick) {
                    SetOpponentPick(4);
                } else {
                    SetTeamPick(4);
                }
            }
        }
    }

    void SetTeamBan(int num) {
        this.gameObject.transform.position = new Vector3(Draft.teamBans[num].gameObject.transform.position.x, Draft.teamBans[num].gameObject.transform.position.y, -1);
        this.gameObject.transform.localScale = new Vector3 (1.05f,1.05f,1.05f);
        GetComponent<SpriteRenderer>().color = Color.red;
        banned = true;
        Draft.phase += 1;
    }

    void SetTeamPick(int num) {
        this.gameObject.transform.position = new Vector3(Draft.teamPicks[num].gameObject.transform.position.x, Draft.teamPicks[num].gameObject.transform.position.y, -1);
        this.gameObject.transform.localScale = new Vector3 (1.05f,1.05f,1.05f);
        picked = true;
        Draft.phase += 1;
    }

    void SetOpponentBan(int num) {
        this.gameObject.transform.position = new Vector3(Draft.opponentBans[num].gameObject.transform.position.x, Draft.opponentBans[num].gameObject.transform.position.y, -1);
        this.gameObject.transform.localScale = new Vector3 (1.05f,1.05f,1.05f);
        GetComponent<SpriteRenderer>().color = Color.red;
        banned = true;
        Draft.phase += 1;
    }

    void SetOpponentPick(int num) {
        this.gameObject.transform.position = new Vector3(Draft.opponentPicks[num].gameObject.transform.position.x, Draft.opponentPicks[num].gameObject.transform.position.y, -1);
        this.gameObject.transform.localScale = new Vector3 (1.05f,1.05f,1.05f);
        picked = true;
        Draft.phase += 1;
    }
    
}
