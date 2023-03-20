using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public bool isGameOver;
    private bool levelFinished;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject nextLevelPanel;

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                isGameOver = false;
            }
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            levelFinished = true;
        }
        if (levelFinished)
        {
            nextLevelPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                NextLevel();
                levelFinished= false;
            }
        }

    }

    public void IsGameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
