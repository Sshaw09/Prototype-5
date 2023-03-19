using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float spawnRate = 1;
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
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
}
