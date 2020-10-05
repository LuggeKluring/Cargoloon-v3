using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Initierar variabler för att använda mellan metoder
    //
    public Rigidbody2D balloon;
    [Range(0.0f, 500.0f)]
    [SerializeField] float moveSpeed = 0;
    [Range(1.0f, 5.0f)]
    [SerializeField] float moveSpeedFactor = 0;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        balloon.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);
        balloon.AddForce(movement * (moveSpeed * moveSpeedFactor) * Time.deltaTime);
        
    }
    
    
    void MoveMobile()
    {
        // Skapa vektor för lutningskontroll
        Vector2 dir = Vector2.zero;
        dir.x = Input.acceleration.x;
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        };
        balloon.transform.Translate(dir * moveSpeed);
        // Ge ballongen kraft uppåt sålänge man rör skärmen
        foreach(Touch touch in Input.touches) {
            if(touch.phase == TouchPhase.Began)
            {
                balloon.transform.Translate(balloon.velocity.x, moveSpeed, 0);
            };
            if(touch.phase == TouchPhase.Ended)
            {
                balloon.transform.Translate(balloon.velocity.x, 0, 0);
            };
        };
    }
}
