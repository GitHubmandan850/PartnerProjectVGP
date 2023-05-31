using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCannon : MonoBehaviour
{
    public GameObject Round;
    public GameObject OutsideTank;
    public GameObject Hatch;

    [SerializeField]
    float zoomFactor = 1.0f;

    [SerializeField]
    float zoomSpeed = 5.0f;

    public PlayerController Player;
    public TankController tonkScript;
    public ShellGrab shellGrab;

    private float originalSize = 0f;

    public bool Shellin = false;
    public bool inCam = false;
    bool CannonActive = false;

    public Camera thisCamera;

    void Start()
    {
        originalSize = thisCamera.orthographicSize;
    }

    void Update()
    {
        if(CannonActive)
        {
            if(Input.GetKeyDown(KeyCode.E) && Shellin == false && shellGrab.hasShell == true)
            {
                shellGrab.Round.SetActive(false);
                Shellin = true;
                Hatch.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E) && Shellin == true)
            {
                zoomFactor = 2;
                Player.speed = 0;
                OutsideTank.SetActive(true);
                inCam = true;
            }
            if(Input.GetKeyUp(KeyCode.E) && Shellin == true)
            {
                zoomFactor = 1;
                Player.speed = 5;
                OutsideTank.SetActive(false);
                inCam = false;
            }
        }

        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CannonActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CannonActive = false;
        }
        
    }
    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }
}