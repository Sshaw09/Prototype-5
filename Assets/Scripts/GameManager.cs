using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    float spawnRate = 1;
    private int score;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public List<GameObject> targets;
    public GameObject titleScreen;
    // Start is called before the first frame update
    // Makes the bool isGameActive true
    // Makes score 0 at start
    //Starts the SpawnTargets()
    //Updates the score UI
    void Start()
    {
        
    }

    //This method only works while the IsGameActive is on
    //An object spawns every second and it picks a item from the list
    IEnumerator SpawnTargets()
    {
        while(isGameActive)
        {
            //Every second, a random object from the list gets spawned in game
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    //Updates the score UI

    public void UpdateScore(int scoreToAdd)
    {
        //Makes the score go up
        scoreText.text = "Score: " + score;
        score += scoreToAdd;
    }

    //This method makes the Game over text & restart button pop up
    //Turns off the IsGameActive 
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }


    //Method for the button so that it can restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTargets());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }
}
