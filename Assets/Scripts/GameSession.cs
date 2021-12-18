using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    // configuration parameters

    // state variables (variables store basic information about level such as score)
    [SerializeField] public int currentScore = 0;
    [SerializeField] float gameSpeed = 0.5f;
    [SerializeField] public bool autoplay = false;
    [SerializeField] public int hitBallCount = 0;
    [SerializeField] public int levelSceneIndex;
    [SerializeField] public int levelNumber = 1;
    [SerializeField] public int totalScore = 0;
    [SerializeField] public bool retried = false;

    private void Awake()
    {
        levelSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
            ResetGame();
        }
    }

    void Start()
    {
        
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return autoplay;
    }

    public void updateScore()
    {
        currentScore++;
        hitBallCount--;
        totalScore++;
        if(hitBallCount == 0)
        {
            levelNumber++;
            if(levelNumber == 6)
            {
                SceneManager.LoadScene("Game Completed");
                Destroy(gameObject);
            }
            retried = false;
            SceneManager.LoadScene(++levelSceneIndex);
            currentScore = 0;
        }
    }
}