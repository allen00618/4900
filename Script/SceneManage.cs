using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public string nextLevelName;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemyObjects)
        {
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player1 == null && player2 == null)
        {
            RestartScene();
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        EnemyLeft();
    }

    public void EnemyLeft()
    {
        if(enemies.Count <= 0)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(nextLevelName);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
