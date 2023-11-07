using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("SampleScene");
        
    }

    public void Controls()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("ControlsScene");
    }

    public void Credits()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("CreditsScene");
    }
    public void ExitGame()
    {
        // Quit the application when the Exit button is pressed.
        Application.Quit();
    }
}
