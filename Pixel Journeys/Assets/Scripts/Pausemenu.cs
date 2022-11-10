using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    [SerializeField] static bool isPaused = false;

    [SerializeField] GameObject pausemenuUI;

    // Start is called before the first frame update
    void Start()
    {
        pausemenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resumeGame()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
