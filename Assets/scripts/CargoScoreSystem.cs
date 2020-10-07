using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoScoreSystem : MonoBehaviour
{
    public int storedCargo;
    public ScoreSystem scoreSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void addCargo()
    {
        storedCargo += 1;
    }
    void dropCargo()
    {
        scoreSystem.addScore(storedCargo * 100);
        storedCargo = 0;
        Debug.Log("New Score: " + scoreSystem.getScore());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cargo")
        {
            addCargo();
            Destroy(collision.gameObject);
            Debug.Log("Stored Cargo: " + storedCargo);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dropzone")
        {
            dropCargo();
        }
    }

}
