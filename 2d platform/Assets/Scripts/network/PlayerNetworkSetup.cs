using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            GetComponent<TouchInput>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
