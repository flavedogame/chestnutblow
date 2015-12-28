using UnityEngine;
using System.Collections;

public class ObstacleTwig : BaseObstacle{
    private Vector3 dropVector = new Vector3(0, 2, 0);
	

    // Update is called once per frame
    void Update()
    {
        transform.position += (dropVector) * Time.deltaTime;
    }
}
