using UnityEngine;
using System.Collections;

public class ObstacleBird : BaseObstacle{
    private Vector3 moveVector = new Vector3(2, 0, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position += (moveVector) * Time.deltaTime;
    }
}
