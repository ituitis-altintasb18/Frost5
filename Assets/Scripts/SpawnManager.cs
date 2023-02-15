using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField]
    private bool isGameActive = true;
    [SerializeField]
    private GameObject enemyPrefab;

    private float ySpawnRange = 1f;
    public float spawnRate = 10f;
    private float sN;
    private float sP;
    private static int numOfZombiesInScene;
    private int maxNumOfZombiesForLevel = 20;


    // Start is called before the first frame update
    void Start()
    {
        numOfZombiesInScene = 0;
        StartCoroutine(SpawnRoutine());
        //spawn negative and spawn positive for multiple different spawn points
        sN = transform.position.y - ySpawnRange;
        sP = transform.position.y + ySpawnRange;
    }
    

    IEnumerator SpawnRoutine()
    {
        while (isGameActive && numOfZombiesInScene <= maxNumOfZombiesForLevel)
        {
            Instantiate(enemyPrefab,
                new Vector3(transform.position.x, Random.Range(sN, sP), 0), Quaternion.identity);
                numOfZombiesInScene += 1;
            yield return new WaitForSeconds(spawnRate);
            Debug.Log(numOfZombiesInScene);
        }
    }

}
