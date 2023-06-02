using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellGrab : MonoBehaviour
{
    public GameObject Round;
    public FireCannon firecan;
    bool CanLoad = false;
    public bool hasShell = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(CanLoad)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Round.SetActive(true);
                hasShell = true;
            }
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CanLoad = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CanLoad = false;
        }
        
    }
}
