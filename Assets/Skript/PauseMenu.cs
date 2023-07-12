using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }
    public void Menu()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("lvl1");
    }


    public void Quit()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Application.Quit();
    }


}
