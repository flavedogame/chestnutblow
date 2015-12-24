using UnityEngine;
using System.Collections;

public class BaseObstacle : MonoBehaviour {
    private Vector3 moveVector = new Vector3(0, 2, 0);
     GameControl gameControl;
	// Use this for initialization
	void Start () {
        gameControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += moveVector * Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
           // coll.gameObject.SendMessage("ApplyDamage", 10);
        
    
        gameControl.GameOver();

    }
}
