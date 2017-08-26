using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatGun : MonoBehaviour
{
    public GameObject meatBulletGO;//this is the name of our prefab
	// Use this for initialization
	void Start ()
    {
        //fire an enemy bullet after 1 seconds
        Invoke("FireMeatBullet", 1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //fire an meat bullet
    void FireMeatBullet()
    {
        //get a reference to the player
        GameObject playerCharacter = GameObject.Find("PlayerGO");

        if(playerCharacter != null)//if the player is not dead
        {
            //instance and ameat bullet
            GameObject meatBullet = (GameObject)Instantiate(meatBulletGO);

            //set the bullet's initial position
            meatBullet.transform.position = transform.position;

            //calculate the bullet's direcion towards the player's position
            Vector2 direction = playerCharacter.transform.position - meatBullet.transform.position;

            //set the bullet's direction
            meatBullet.GetComponent<meatBullet>().SetDirection(direction);
        }
    }
}
