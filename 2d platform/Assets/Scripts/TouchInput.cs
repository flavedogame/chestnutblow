using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

    public GameObject windPrefab;
    public GameObject chestnutGo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {

            Vector3 mousePosition = Input.mousePosition;
           // Instantiate(windPrefab, mousePosition, Quaternion.identity);
            Vector3 chestnutPosition =  Camera.main.WorldToScreenPoint(chestnutGo.transform.position);
            //Debug.Log(chestnutPosition + " "+ mousePosition);
            chestnutGo.GetComponent<Rigidbody2D>().AddForce((chestnutPosition - mousePosition).normalized * Time.deltaTime * 115f);

        }

        if (Input.touchCount > 0)
        {
            Vector3 mousePosition = Input.GetTouch(0).position;
            // Instantiate(windPrefab, mousePosition, Quaternion.identity);
            Vector3 chestnutPosition = Camera.main.WorldToScreenPoint(chestnutGo.transform.position);
           // Debug.Log(chestnutPosition + " " + mousePosition);
            chestnutGo.GetComponent<Rigidbody2D>().AddForce((chestnutPosition - mousePosition).normalized * Time.deltaTime * 115f);
        }
	}
}
