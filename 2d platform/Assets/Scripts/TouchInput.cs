using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TouchInput : NetworkBehaviour {

    public GameObject chestnutGo;

    public GameObject fingerPointPrefab;
    private Vector3 fingerPointDefaultPosition = new Vector3(100, 100, 0);
    private Vector3 fingerPointZAdjust = new Vector3(0, 0, 10);

    public bool isActive;
    public bool flipActive;
    public Vector3 mousePosition;

	// Use this for initialization
	void Start () {
        fingerPointPrefab = gameObject;
        chestnutGo = GameObject.FindGameObjectWithTag("Player");
        isActive = false;
        flipActive = false;
        //gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButton(0))
            {

                mousePosition = Input.mousePosition;
                // Instantiate(windPrefab, mousePosition, Quaternion.identity);
                // Vector3 chestnutPosition = Camera.main.WorldToScreenPoint(chestnutGo.transform.position);
                //Debug.Log(chestnutPosition + " "+ mousePosition);
                // chestnutGo.GetComponent<Rigidbody2D>().AddForce((chestnutPosition - mousePosition).normalized * Time.deltaTime * 115f);
                fingerPointPrefab.transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + fingerPointZAdjust;
                if (!isActive)
                {
                    //gameObject.SetActive(true);

                    isActive = true;
                    flipActive = true;
                }
            }


            else if (Input.touchCount > 0)
            {
                mousePosition = Input.GetTouch(0).position;
                // Instantiate(windPrefab, mousePosition, Quaternion.identity);

                fingerPointPrefab.transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + fingerPointZAdjust;

                if (!isActive)
                {
                    //gameObject.SetActive(true);
                    isActive = true;
                    flipActive = true;
                }
            }
            else
            {
                fingerPointPrefab.transform.position = fingerPointDefaultPosition;
                //gameObject.SetActive(false);
                isActive = false;
                flipActive = false;
            }
        }
	}
}
