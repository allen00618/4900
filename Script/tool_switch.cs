using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tool_switch : MonoBehaviour
{
    public GameObject tool1;
    public GameObject tool2;
    public KeyCode switchButton;
    public GameObject bulletPrefab;
    public GameObject stonePrefab;
    public int stonePlaced = 0;
    private bool istool1Active = true;
    public float dropRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        tool1.SetActive(true);
        tool2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(istool1Active)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q))
            {
                //GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }
        else 
        {
            if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q)) && (stonePlaced < 3))
            {
                StartCoroutine(DropStoneWithDelay(dropRate));
            }
        }

        if(Input.GetKeyDown(switchButton))
        {
            istool1Active = !istool1Active;
            tool1.SetActive(istool1Active);
            tool2.SetActive(!istool1Active);
        }
    }

    IEnumerator DropStoneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        Vector3 dropPosition = transform.position - new Vector3(0f, 1f, 0f);
        GameObject stone = Instantiate(stonePrefab, dropPosition, Quaternion.identity);
        stonePlaced++;
    }
}