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
    [SerializeField] AudioClip click;

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
        GetComponent<AudioSource>().PlayOneShot(click);
        Destroy(gs);
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
        if (gs.retried)
        {
            StartCoroutine(DisplayErr("CAN RETRY ONLY ONCE!"));
            GetComponent<AudioSource>().Play();
        }
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
