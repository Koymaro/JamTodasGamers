using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //reference to our game objects
    public GameObject playButton;
    public GameObject playerChracter;
    public GameObject enemySpawner;//reference to our enemy spawner
    public GameObject GameOverGO;//reference to the game over image
    public GameObject scoreUITextGO;//reference to the score text ui game object
    public GameObject titleGO;//reference to the title image

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver
    }

    GameManagerState GMState;

	// Use this for initialization
	void Start ()
    {
        GMState = GameManagerState.Opening;
	}
	
	//update the gameManager state
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                //hide game over
                GameOverGO.SetActive(false);

                //set title visible
                titleGO.SetActive(true);

                //set play button visible
                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                //reset the score
                scoreUITextGO.GetComponent<gameScore>().Score = 0;

                //hide play button on game play state
                playButton.SetActive(false);

                //hide title
                titleGO.SetActive(false);

                //set the player visible and init the player lives
                playerChracter.GetComponent<playerControl>().Init();

                //start enemy spawner
                enemySpawner.GetComponent<enemiesSpawner>().ScheduleEnemySpawner();

                break;
            case GameManagerState.GameOver:

                //stopr enemy spawner
                enemySpawner.GetComponent<enemiesSpawner>().UnschedulEnemySpawner();

                //display game over
                GameOverGO.SetActive(true);

                //change game manager state to opening state
                Invoke("ChangeToOpeningState", 8f);

                break;
        }
    }

    //function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //our play button will call this function
    //when the user clicks the button
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
