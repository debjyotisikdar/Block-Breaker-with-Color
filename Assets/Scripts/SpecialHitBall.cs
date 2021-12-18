using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialHitBall : MonoBehaviour
{
    [SerializeField] string color;
    [SerializeField] Ball ball;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] string[] colors;
    [SerializeField] Sprite[] sprites;
    [SerializeField] int primaryIndex = 0;
    [SerializeField] float changeDelay = 0.301029995663981f;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        FindObjectOfType<GameSession>().hitBallCount++;
        color = colors[primaryIndex];
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[primaryIndex];
        updateSprite();
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

    private void updateSprite()
    {
        sr.sprite = sprites[primaryIndex];
        color = colors[primaryIndex];
        if (++primaryIndex == sprites.Length)
            primaryIndex = 0;
        StartCoroutine(main());
    }

    private IEnumerator main()
    {
        yield return new WaitForSeconds(changeDelay);
        updateSprite();
    }
}
