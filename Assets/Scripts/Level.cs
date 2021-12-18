using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<Text>();
        levelText = FindObjectOfType<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = FindObjectOfType<GameSession>().currentScore.ToString();
        levelText.text = FindObjectOfType<GameSession>().levelNumber.ToString();
    }
}
