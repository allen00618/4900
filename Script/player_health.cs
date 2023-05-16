using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_health : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public TextMeshProUGUI livesText;
    public string playerLabel;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        UpdateLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
            currentLives = 0;
            UpdateLivesText();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            currentLives--;
            if(currentLives <= 0)
            {
                Destroy(gameObject);
            }
            UpdateLivesText();
        }

        if(collision.gameObject.CompareTag("meteor"))
        {
            currentLives = 0;
            Destroy(gameObject);
            UpdateLivesText();
        }

        if(collision.gameObject.CompareTag("heart"))
        {
            Destroy(collision.gameObject);
            currentLives++;
            UpdateLivesText();
        }
    }

    void UpdateLivesText()
    {
        livesText.text = playerLabel + " Lives: " + currentLives.ToString();
    }
}