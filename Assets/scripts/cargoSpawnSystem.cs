using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargoSpawnSystem : MonoBehaviour
{
    private float coordX;
    private float coordY;
    [Range(1,10)]
    [SerializeField] float spawnDelay;
    [Range(1, 99)]
    [SerializeField] int spawnQty = 1;
    [Range(1, 10)]
    [SerializeField] float initTime;
    public Rigidbody2D cargo;
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
        coordX = Random.Range(0.5f, 11.6f);
        coordY = Random.Range(7.5f, 8.5f);
        cargo = Instantiate(cargo, new Vector2(coordX, coordY), Quaternion.identity);

        /*
        for (int i = 0; i < spawnQty; i++)
        {
            System.Console.Out.Write("Spawn");
            coordX = Random.Range(0.5f, 11.6f);
            coordY = Random.Range(7.5f, 8.5f);
            transform.position = new Vector2(coordX, coordY);
            cargoBox = Instantiate(cargo, transform.position, Quaternion.identity);
        }
        */
    }
}
