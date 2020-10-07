using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnSystem : MonoBehaviour
{
    [SerializeField] float cloudSpawnTime = 1f;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public Camera screenBounds;
    [Range(1f, 1000f)][SerializeField] float cloudSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCloud());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnCloud()
    {
        while (true)
        {
            
            Vector2 spawnVector = screenBounds.ViewportToWorldPoint(new Vector2(Random.Range(-0.7f, -0.4f), Random.Range(0.05f, 0.95f)));
            int dice = Random.Range(0, 3);
            if(dice == 0)
            {

                cloud1 = Instantiate(cloud1, spawnVector, Quaternion.identity);
                Rigidbody2D rb2d = cloud1.GetComponent<Rigidbody2D>();
                rb2d.AddForce(new Vector2(cloudSpeed, 0));
            }
            if (dice == 1)
            {

                cloud2 = Instantiate(cloud2, spawnVector, Quaternion.identity);
                Rigidbody2D rb2d = cloud2.GetComponent<Rigidbody2D>();
                rb2d.AddForce(new Vector2(cloudSpeed, 0));
            }
            if (dice == 2)
            {

                cloud3 = Instantiate(cloud3, spawnVector, Quaternion.identity);
                Rigidbody2D rb2d = cloud3.GetComponent<Rigidbody2D>();
                rb2d.AddForce(new Vector2(cloudSpeed, 0));
            }
            yield return new WaitForSeconds(cloudSpawnTime);
        }
    }
}
