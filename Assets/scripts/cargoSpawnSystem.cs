using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargoSpawnSystem : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] float spawnDelay = 0;
    //[Range(1, 99)]
    //[SerializeField] int spawnQty = 1;
    [Range(1, 10)]
    [SerializeField] float initTime = 1;
    public Rigidbody2D cargo;
    public Camera screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCargo", initTime, spawnDelay);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCargo()
    {
        Vector2 spawnVector = screenBounds.ViewportToWorldPoint(new Vector2(Random.Range(0.05f, 0.95f), Random.Range(1.2f, 1.5f)));
        cargo = Instantiate(cargo, spawnVector, Quaternion.identity);

    }
}
