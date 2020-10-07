using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnSystem : MonoBehaviour
{
    [Range(1f, 100f)] [SerializeField] float obstacleSpawnDelay = 10;
    [Range(1f, 100f)] [SerializeField] float birdsPerSpawn = 1;
    [Range(1f, 100f)] [SerializeField] float bombsPerSpawn = 1;
    [SerializeField] float flySpeed = 1;
    public int spawnQty;
    [SerializeField] GameObject birdFlyRight;
    [SerializeField] GameObject birdFlyLeft;
    [SerializeField] GameObject bomb;
    public Camera screenBounds;
    public ScoreSystem scoreSystem;
    //[SerializeField] GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBirdsRight()
    {
        
        Vector2 spawnVector = screenBounds.ViewportToWorldPoint(new Vector2(Random.Range(-0.5f, -0.2f), Random.Range(0f, 1f)));
        for (int i = 0; i < birdsPerSpawn; i++)
        {
            birdFlyRight = Instantiate(birdFlyRight, spawnVector, Quaternion.identity);
            Rigidbody2D rb2d = birdFlyRight.GetComponent<Rigidbody2D>();
            rb2d.AddForce(new Vector2(flySpeed, 0));
        }
    }
    void SpawnBirdsLeft()
    {
        
        Vector2 spawnVector = screenBounds.ViewportToWorldPoint(new Vector2(Random.Range(1.2f, 1.5f), Random.Range(0f, 1f)));
        for (int i = 0; i < birdsPerSpawn; i++)
        {
            birdFlyLeft = Instantiate(birdFlyLeft, spawnVector, Quaternion.identity);
            Rigidbody2D rb2d = birdFlyLeft.GetComponent<Rigidbody2D>();
            rb2d.AddForce(new Vector2(-flySpeed, 0));

        }
    }
    void SpawnBombs()
    {
        
        Vector2 spawnVector = screenBounds.ViewportToWorldPoint(new Vector2(Random.Range(0f, 1f), Random.Range(1.2f, 1.5f)));
        for (int i = 0; i < bombsPerSpawn; i++)
        {
            bomb = Instantiate(bomb, spawnVector, Quaternion.identity);
        }
    }
    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(obstacleSpawnDelay);
            spawnQty = (scoreSystem.getScore() / 150) +1;
            Debug.Log("Spawn Quantity: " + spawnQty);
            for (int i = 0; i < spawnQty; i++)
            {
                int dice;
                dice = Random.Range(0, 4);
                
                if (dice == 1)
                {
                    SpawnBirdsLeft();
                }
                if (dice == 2)
                {
                    SpawnBirdsRight();

                }
                if (dice == 3)
                {
                    SpawnBombs();
                }
                else
                {
                    Debug.Log("Missat loop");
                }
                
            }
        }
    }
}
