﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int score)
    {
        this.score += score;
        Debug.Log("Score: " + this.score);
    }
    public int getScore()
    {
        return score;
    }
}
