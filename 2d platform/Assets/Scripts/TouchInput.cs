using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

    public GameObject chestnutGo;

    public GameObject fingerPointPrefab;
    private Vector3 fingerPointDefaultPosition = new Vector3(100, 100, 0);
    private Vector3 fingerPointZAdjust = new Vector3(0, 0, 10);

	// Use this for initialization
	void Start () {
        fingerPointPrefab = gameObject;
        chestnutGo = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {

            Vector3 mousePosition = Input.mousePosition;
            // Instantiate(windPrefab, mousePosition, Quaternion.identity);
            Vector3 chestnutPosition = Camera.main.WorldToScreenPoint(chestnutGo.transform.position);
            //Debug.Log(chestnutPosition + " "+ mousePosition);
            chestnutGo.GetComponent<Rigidbody2D>().AddForce((chestnutPosition - mousePosition).normalized * Time.deltaTime * 115f);
            fingerPointPrefab.transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + fingerPointZAdjust;
        }


        else if (Input.touchCount > 0)
        {
            Vector3 mousePosition = Input.GetTouch(0).position;
            // Instantiate(windPrefab, mousePosition, Quaternion.identity);
            Vector3 chestnutPosition = Camera.main.WorldToScreenPoint(chestnutGo.transform.position);
            // Debug.Log(chestnutPosition + " " + mousePosition);
            chestnutGo.GetComponent<Rigidbody2D>().AddForce((chestnutPosition - mousePosition).normalized * Time.deltaTime * 115f);
            fingerPointPrefab.transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + fingerPointZAdjust;
        }
        else {
            fingerPointPrefab.transform.position = fingerPointDefaultPosition;
        }
	}
}
