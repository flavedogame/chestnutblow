using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class PlayerSyncPosition : NetworkBehaviour {
    [SyncVar]
    private Vector3 syncPos;
    [SerializeField]
    Transform myTransform;
    [SerializeField]
    float lerpRate = 15;

	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        TransmitPosition();
        lerpPosition();
    }

    void lerpPosition() {
        if (!isLocalPlayer) {
            myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
        }
    
    }
    [Command]
    //run on server, call on client
    void CmdProvidePositionToServer(Vector3 pos) {
        syncPos = pos;
    }

    [ClientCallback]
    void TransmitPosition() {
        if (isLocalPlayer)
        {
            CmdProvidePositionToServer(myTransform.position);
        }
    
    }
}
