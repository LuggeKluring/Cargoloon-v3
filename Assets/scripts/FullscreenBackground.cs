using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        GameObject background = this.gameObject;
        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 backgroundSize = background.GetComponent<SpriteRenderer>().bounds.size;

    }
}
