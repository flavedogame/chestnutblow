using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class PlayerSyncPosition : NetworkBehaviour {
    [SyncVar]
    private Vector3 syncPos;
    [SyncVar]
    private bool isActive;
    [SerializeField]
    Transform myTransform;
    [SerializeField]
    float lerpRate = 15;

	// Use this for initialization
	void Start () {
        myTransform = transform;
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        lerpPosition();
	}

    void FixedUpdate() {
        TransmitPosition();
        
    }

    void lerpPosition() {
        if (!isLocalPlayer) {
            myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
            GetComponent<TouchInput>().isActive = isActive;
        }
    
    }
    [Command]
    //run on server, call on client
    void CmdProvidePositionToServer(Vector3 pos,bool act) {
        syncPos = pos;
        isActive = act;
    }

    [ClientCallback]
    void TransmitPosition() {
        if (isLocalPlayer)
        {
            CmdProvidePositionToServer(myTransform.position,GetComponent<TouchInput>().isActive);
        }
    
    }
}
