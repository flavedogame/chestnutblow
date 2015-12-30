using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_ID : NetworkBehaviour {

    [SyncVar]
    public string playerUniqueName;
    private NetworkInstanceId playerNetID;
    private Transform myTransform;

    public override void OnStartLocalPlayer()
    {
        GetNetIdentity();
        SetIdentity();
    }

	// Use this for initialization
	void Awake () {
        myTransform = transform;
	}

    [Client]
    void GetNetIdentity()
    {
        playerNetID = GetComponent<NetworkIdentity>().netId;
        CmdTellServerMyIdentity(MakeUniqueName());
    
    }

    [Client]
    void SetIdentity() {
        if (isLocalPlayer)
        {
            myTransform.name = MakeUniqueName();

        }
        else {
            myTransform.name = playerUniqueName;
        }
    }

    string MakeUniqueName() {
        string uniqueName = "Player " + playerNetID.ToString();
        return uniqueName;
    }

    [Command]
    void CmdTellServerMyIdentity(string name)
    {
        playerUniqueName = name;
    }

	
	// Update is called once per frame
	void Update () {
        if (myTransform.name == "" || myTransform.name == "fingerPoint(Clone)") {
            SetIdentity();
        }
	}
}
