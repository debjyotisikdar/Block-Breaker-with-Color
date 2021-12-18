using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Serialized parameters
    [SerializeField] Text versionText;

    // Cached reference(s)
    AudioSource thisAS;

    // Start is called before the first frame update
    void Start()
    {
        versionText.text = "Version " + Application.version.ToString();
        thisAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        thisAS.PlayOneShot(thisAS.clip);
        Application.Quit();
    }

    public void StartGame()
    {
        thisAS.PlayOneShot(thisAS.clip);
        SceneManager.LoadScene("Help");
    }

    public void LoadPreferences()
    {
        thisAS.PlayOneShot(thisAS.clip);
        SceneManager.LoadScene("Preferences");
    }

    public void ViewRepo()
    {
        thisAS.PlayOneShot(thisAS.clip);
        Application.OpenURL("https://github.com/debjyotisikdar/Block-Breaker-with-Color");
    }
}
