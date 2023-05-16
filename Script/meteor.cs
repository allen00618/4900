using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public GameObject meteorPrefab;
    public int minRocks = 1;
    public int maxRocks = 3;
    public float fallTime = 15f;
    private bool isFalling = false;
    //private float fallSpeed = 10f;
    private float nextFallTime;

    // Start is called before the first frame update
    void Start()
    {
        nextFallTime = Time.time + fallTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFalling && Time.time >= nextFallTime)
        {
            isFalling = true;
            //GetComponent<Rigidbody2D>().gravityScale = fallSpeed;
            nextFallTime = Time.time + fallTime;
            SpawnMeteor();
        }
    }
    
    void SpawnMeteor()
    {
        isFalling = false;
        int numRocks = Random.Range(minRocks, maxRocks + 1);
        for(int i = 0; i < numRocks; i++)
        {
            float randomDrop = Random.Range(-9, 9);
            GameObject meteorInstance = Instantiate(meteorPrefab, new Vector3(randomDrop, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(meteorInstance, 9f);
        }
    }
}