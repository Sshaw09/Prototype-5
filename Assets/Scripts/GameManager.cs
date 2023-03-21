using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    float spawnRate = 1;
    private int score;
    public TextMeshProUGUI scoreText;

    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());

        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while(true)
        {
            //Every second, a random object from the list gets spawned in game
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           }
    }

    public void UpdateScore(int scoreToAdd)
    {
        //Makes the score go up
        scoreText.text = "Score: " + score;
        score += scoreToAdd;
    }
}
