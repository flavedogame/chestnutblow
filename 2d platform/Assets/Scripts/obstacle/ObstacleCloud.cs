using UnityEngine;
using System.Collections;

public class ObstacleCloud : BaseObstacle{
    private Vector3 dropVector = new Vector3(0, 2, 0);
	

    // Update is called once per frame
    void Update()
    {
        transform.position += (dropVector) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            //it should do some animation and/or play sound so player knows the cloud does something

            other.gameObject.GetComponent<Rigidbody2D>().mass = 4;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale =-0.02f;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x/2,0);
            
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            // coll.gameObject.SendMessage("ApplyDamage", 10);


            other.gameObject.GetComponent<Rigidbody2D>().mass = 1;
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.02f;

    }
}
