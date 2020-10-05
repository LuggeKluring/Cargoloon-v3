using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnSystem : MonoBehaviour
{
    [Range(1f, 100f)] [SerializeField] float obstacleSpawnDelay = 1;
    [Range(1f, 100f)] [SerializeField] float birdsPerSpawn = 1;
    [Range(1f, 100f)] [SerializeField] float bombsPerSpawn = 1;
    public int score;
    [SerializeField] GameObject birdFlyRight;
    [SerializeField] GameObject birdFlyLeft;
    [SerializeField] GameObject bomb;
    //[SerializeField] GameObject player;
    private float bombSpawnCoordX;
    private float bombSpawnCoordY;
    private float birdSpawnCoordX;
    private float birdSpawnCoordY;
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem.instance.addScore(1000);
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBirdsRight()
    {
        for (int i = 0; i < birdsPerSpawn; i++)
        {
            birdSpawnCoordX = Random.Range(-0.38f, -2);
            birdSpawnCoordY = Random.Range(0.25f, 6.6f);
            birdFlyRight = Instantiate(birdFlyRight, new Vector2(birdSpawnCoordX, birdSpawnCoordY), Quaternion.identity);
        }
    }
    void SpawnBirdsLeft()
    {
        for (int i = 0; i < birdsPerSpawn; i++)
        {
            birdSpawnCoordX = Random.Range(14.7f, 16f);
            birdSpawnCoordY = Random.Range(0.25f, 6.6f);
            birdFlyLeft = Instantiate(birdFlyLeft, new Vector2(birdSpawnCoordX, birdSpawnCoordY), Quaternion.identity);
        }
    }
    void SpawnBombs()
    {
        for (int i = 0; i < bombsPerSpawn; i++)
        {
            bombSpawnCoordX = Random.Range(-1.9f, 14.0f);
            bombSpawnCoordY = Random.Range(7.2f, 9.0f);
            bomb = Instantiate(bomb, new Vector2(bombSpawnCoordX, bombSpawnCoordY), Quaternion.identity);
        }
    }
    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            Debug.Log("Score: " + score);
            yield return new WaitForSeconds(obstacleSpawnDelay);
            score = (ScoreSystem.instance.getScore() / 100) +1;
            for (int i = 0; i <= score; i++)
            {
                float dice;
                dice = Random.Range(1f, 3f);
                if (dice == 1f)
                {
                    SpawnBirdsLeft();

                }
                if (dice == 2f)
                {
                    SpawnBirdsRight();

                }
                if (dice == 3f)
                {
                    SpawnBombs();
                }
                else
                {
                    Debug.Log("Fel");
                }
                
            }
        }
    }
}
