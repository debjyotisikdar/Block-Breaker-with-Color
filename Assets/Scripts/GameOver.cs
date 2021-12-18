using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Serialized parameters
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] Text messageArea;
    [SerializeField] GameSession gs;

    // Start is called before the first frame update
    void Start()
    {
        gs = FindObjectOfType<GameSession>();
        scoreText.text = "Score : " + gs.totalScore.ToString();
        levelText.text = "Level : " + gs.levelNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Destroy(gs);
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        if (gs.retried)
            StartCoroutine(DisplayErr("CAN RETRY ONLY ONCE!"));
        else
        {
            gs.currentScore = 0;
            gs.hitBallCount = 0;
            SceneManager.LoadScene(gs.levelSceneIndex);
            gs.retried = true;
        }
    }

    private IEnumerator DisplayErr(string msg)
    {
        messageArea.text = msg;
        yield return new WaitForSeconds(3f);
        messageArea.text = "";
    }
}
