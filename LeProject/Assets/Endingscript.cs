using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endingscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject aiToCheck = GameObject.Find("AI");

        if (aiToCheck == null)
        {
            SceneManager.LoadScene("ZuckWon");
        }

        GameObject playerToCheck = GameObject.Find("Player");

        if (playerToCheck == null)
        {
            SceneManager.LoadScene("MuskWon");
        }
    }
}
