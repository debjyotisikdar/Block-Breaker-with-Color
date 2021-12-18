using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Preferences : MonoBehaviour
{
    // Serialized parameters
    [SerializeField] AudioSource thisSFXAS;
    [SerializeField] AudioSource thisMusicAS;
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider quailtySlider;

    // Start is called before the first frame update
    void Start()
    {
        float val1;
        bool sfxGetResult = audioMixer.GetFloat("sfxVolume", out val1);
        if (sfxGetResult)
            sfxSlider.SetValueWithoutNotify(val1);

        float val2;
        bool musicGetResult = audioMixer.GetFloat("musicVolume", out val2);
        if (musicGetResult)
            musicSlider.SetValueWithoutNotify(val2);

        quailtySlider.SetValueWithoutNotify(QualitySettings.GetQualityLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        thisSFXAS.PlayOneShot(thisSFXAS.clip);
        SceneManager.LoadScene("Main Menu");
    }

    public void changeSFX(float val)
    {
        audioMixer.SetFloat("sfxVolume", val);
        thisSFXAS.PlayOneShot(thisSFXAS.clip);
    }

    public void changeMusic(float val)
    {
        audioMixer.SetFloat("musicVolume", val);
        thisMusicAS.PlayOneShot(thisMusicAS.clip);
    }

    public void setQuality(float val)
    {
        QualitySettings.SetQualityLevel((int) val);
        thisSFXAS.PlayOneShot(thisSFXAS.clip);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
