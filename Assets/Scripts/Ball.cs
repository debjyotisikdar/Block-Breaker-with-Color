using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    // Configuration Parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 1f, yPush = 1f;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] AudioClip clip;
    [SerializeField] string currentString;
    [SerializeField] Sprite[] sprites;
    [SerializeField] string[] spriteColors;
    [SerializeField] int spriteIndex = 0;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] Image spriteImg;
    [SerializeField] Sprite emptySprite;

    // state
    Vector2 paddleToBallVector;
    [SerializeField] bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[spriteIndex];
        myAudioSource.PlayOneShot(spawnSound);
        spriteImg.sprite = sprites[spriteIndex + 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LaunceOnSpacePress();
            LockBallToPaddle();
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    }

    private void LaunceOnSpacePress()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 ballPos = new Vector3(paddle.transform.position.x, paddle.transform.position.y, -1f);
        transform.position = ballPos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public void dealWithCollision()
    {
        Debug.Log("Received function call!");
        spriteIndex++;
        if(spriteIndex < sprites.Length)
        {
            myAudioSource.PlayOneShot(spawnSound);
            sr.sprite = sprites[spriteIndex];
            hasStarted = false;
            LaunceOnSpacePress();
            LockBallToPaddle();
            Debug.Log("Current Sprite Index : " + spriteIndex + ", next : " + (spriteIndex + 1));
            spriteImg.sprite = (spriteIndex + 1 == sprites.Length) ? emptySprite : sprites[spriteIndex + 1];
        }
        else
        {
            // Add extra game over code if needed
            SceneManager.LoadScene("Game Over");
        }
        
    }

    public string retColor()
    {
        return spriteColors[spriteIndex];
    }
}
