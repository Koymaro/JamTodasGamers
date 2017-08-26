using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaser : MonoBehaviour
{
    float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Get the laser's current position
        Vector2 position = transform.position;

        //calculate the laser's new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //update the laser's position
        transform.position = position;

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //if the laser went outside the screen on the top, then destroy the laser
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}
}
