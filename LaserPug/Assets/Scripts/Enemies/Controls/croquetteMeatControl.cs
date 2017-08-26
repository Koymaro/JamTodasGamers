using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class croquetteMeatControl : MonoBehaviour
{
    float speed;//for the enemy speed
	//use this for initialization
	void Start ()
    {
        speed = 2f;//set speed
	}
	
	//update is called once per frame
	void Update ()
    {
        //get the enemy current position
        Vector2 position = transform.position;

        //calculate the enemy new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update the enemy position
        transform.position = position;

        //this is the bottom-left point the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //if the enemy outside the screen on the bottom, then destroy the enemy
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

	}
}
