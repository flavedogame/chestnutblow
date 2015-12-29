using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class chestnutNetworkMove : NetworkBehaviour {

    private GameObject myPlayer;
    private GameObject otherPlayer;//can be multi 




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isServer)
        {
            pushChestnut();
        }
	}

    [Server]
    public void pushChestnut() {
        //ehh,nasty
        if (otherPlayer == null)
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag(StaticValues.fingerPoint);
            if (go.Length == 2)
            {
                Debug.Log("find two go");
                myPlayer = go[0];
                otherPlayer = go[1];
            }
        }
        else
        {
            Vector3 chestnutPosition = Camera.main.WorldToScreenPoint(transform.position);
            // Debug.Log(chestnutPosition + " " + mousePosition);
            Vector3 force = Vector3.zero;
            if (myPlayer.GetComponent<TouchInput>().isActive)
            {
                Debug.Log("my player is active");
                force = (chestnutPosition -Camera.main.WorldToScreenPoint( myPlayer.GetComponent<TouchInput>().transform.position)).normalized;
            }
            if (otherPlayer.GetComponent<TouchInput>().isActive)
            {
                force += ((chestnutPosition - Camera.main.WorldToScreenPoint(otherPlayer.GetComponent<TouchInput>().transform.position)).normalized);
            }
            GetComponent<Rigidbody2D>().AddForce(force * Time.deltaTime * 115f);

        }
        RpcPushChestnut(transform.position);
    }

    [ClientRpc]
    public void RpcPushChestnut(Vector3 pos) {
        transform.position = pos;
    }
}
