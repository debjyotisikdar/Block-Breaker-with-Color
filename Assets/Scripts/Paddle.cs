using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Serialized parameters
    [SerializeField] bool autoplay = false;
    [SerializeField] float speed = 0.075f;

    // Cached references
    GameSession gs;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gs = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!autoplay)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed * Time.deltaTime, -4.6f, 4.6f), transform.position.y, -1f);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x - speed * Time.deltaTime, -4.6f, 4.6f), transform.position.y, -1f);
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x, -4.6f, 4.6f), transform.position.y, -1f);
        }

        if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.L))
        {
            autoplay = !autoplay;
            GetComponent<AudioSource>().Play();
        }
    }
}
