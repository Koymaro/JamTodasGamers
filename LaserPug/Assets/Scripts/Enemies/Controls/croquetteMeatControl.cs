using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class croquetteMeatControl : MonoBehaviour
{
    GameObject scoreUITextGO;//reference to the text ui game object

    public GameObject croquetteMeatDeadGO;//this is our dead prefab

    float speed;//for the enemy speed
	//use this for initialization
	void Start ()
    {
        speed = 2f;//set speed

        //get the score text ui
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
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

    //will trigger when detect a collision of our game objects
    void OnTriggerEnter2D(Collider2D col)
    {
        //detect colision of the player character with an enemy character or with an enemy bullet
        if ((col.tag == "PlayerCharacterTag") || (col.tag == "PlayerBulletTag"))
        {
            Destroy(gameObject);

            //add 10 points to the score
            scoreUITextGO.GetComponent<gameScore>().Score += 10;

            PlayDead();
        }
    }

    //instantiate the explosion dead
    void PlayDead()
    {
        GameObject dead = (GameObject)Instantiate(croquetteMeatDeadGO);

        //set the position of the explosion
        dead.transform.position = transform.position;

    }
}
