using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    // Serialized parameters
    [SerializeField] public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Main Menu");
    }
}
