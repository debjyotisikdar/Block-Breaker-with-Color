using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private void Awake()
    {
        int thisCount = FindObjectsOfType<MenuMusic>().Length;
        if (thisCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
