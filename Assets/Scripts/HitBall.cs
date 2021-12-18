using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    [SerializeField] string color;
    [SerializeField] Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        FindObjectOfType<GameSession>().hitBallCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Collision with destructible ball.");
        if (ball.retColor() == color)
        {
            FindObjectOfType<GameSession>().updateScore();
            Destroy(gameObject);
        }
    }
}
