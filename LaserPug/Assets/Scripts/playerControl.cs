using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public GameObject playerLaserGO;//this is our player's laser prefab
    public GameObject laserPosition01;
    public GameObject laserPosition02;

    public float speed;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //fire laser when the spacebar is pressed
        if(Input.GetKeyDown("space"))
        {
            //instantiate the first laser
            GameObject laser01 = (GameObject)Instantiate(playerLaserGO);
            laser01.transform.position = laserPosition01.transform.position;//set the laser initial position

            //instantiate the second laser
            GameObject laser02 = (GameObject)Instantiate(playerLaserGO);
            laser02.transform.position = laserPosition02.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");//the value will be -1, 0, or 1 (for left, no input and right)
        float y = Input.GetAxisRaw("Vertical");//the value will be -1, 0 or 1 (for down, no input and up)

        //now based on the input we compute a direction vector and we normalize it to get a unit vector
        Vector2 direction = new Vector2(x, y).normalized;

        //now we call the function that computes and sets the player's position
        Move(direction);

	}

    void Move(Vector2 direction)
    {
        //Find the screen limits to the player's movement (left, right, top and bottom edges of the screen)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //this is the bottom-left point (corner) of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //this is the top-right point (corner) of the screen

        max.x = max.x - 0.225f; //subtract the player sprite half width
        min.x = min.x + 0.225f; //add the player sprite half width

        max.y = max.y - 0.285f; //subtract the player sprite half height
        min.y = min.y + 0.285f; //add the player sprite half height

        //Get the player's current position
        Vector2 playerPos = transform.position;

        //Calculate the new position
        playerPos += direction * speed * Time.deltaTime;

        //Make sure the new position is not ourtisde the screen
        playerPos.x = Mathf.Clamp(playerPos.x, min.x, max.x);
        playerPos.y = Mathf.Clamp(playerPos.y, min.y, max.y);

        //Update the player's postion
        transform.position = playerPos;
    }
}
