using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_elite : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveDistance = 3f;
    private bool movingRight = true;
    private Vector2 initialPosition;
    public GameObject[] activate_enemy;
    public GameObject heart;
    public float chanceToSpawnHeart = 0.33f;
    public int maxLives = 3;
    private int currentLives;
    private SceneManage sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        currentLives = maxLives;
        sceneManager = FindObjectOfType<SceneManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if(transform.position.x > initialPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if(transform.position.x < initialPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }

    private void OnDestroy()
    {
        if(sceneManager != null)
        {
            sceneManager.RemoveEnemy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            currentLives--;
            
            if(currentLives <= 0)
            {
                Destroy(gameObject);

                if(Random.value < chanceToSpawnHeart)
                {
                    heart.SetActive(true);
                }
                foreach(GameObject enemy in activate_enemy)
                {
                    enemy.SetActive(true);
                }
            }
        }
    }
}