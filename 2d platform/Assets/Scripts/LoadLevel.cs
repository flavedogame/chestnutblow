using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void load(string levelName) 
    {
        Application.LoadLevel(levelName);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
