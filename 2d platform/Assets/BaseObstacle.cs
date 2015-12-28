using UnityEngine;
using System.Collections;

public class BaseObstacle : MonoBehaviour {
    
   // 
     GameControl gameControl;
	// Use this for initialization
	void Start () {
        gameControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
	}
	
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
           // coll.gameObject.SendMessage("ApplyDamage", 10);
        
    
        gameControl.GameOver();

    }
}
