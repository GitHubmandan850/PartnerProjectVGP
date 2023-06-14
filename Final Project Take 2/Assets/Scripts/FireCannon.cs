using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCannon : MonoBehaviour
{
    public Animator Soilder;
    public FireCannon fire;
    public Animator Cam;
    public Animator Tank;
    public GameObject back;
    public GameObject Round;
    public GameObject OutsideTank;
    public GameObject Hatch;

    [SerializeField]
    float zoomFactor = 1.0f;

    [SerializeField]
    float zoomSpeed = 5.0f;

    public TankController tonkScript;
    public ShellGrab shellGrab;
    public PlayerController Player;

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
            if(Input.GetKeyUp(KeyCode.E) && Shellin == true)
            {
                zoomFactor = 1;
                Player.speed = 5;
                OutsideTank.SetActive(false);
                inCam = false;
            }
            if(Input.GetKeyDown(KeyCode.E) && Shellin == false && shellGrab.hasShell == true)
            {
                shellGrab.Round.SetActive(false);
                Shellin = true;
                Hatch.SetActive(true);
                shellGrab.Round.SetActive(false);
                shellGrab.hasShell = false;
                
            }
            else if(Input.GetKeyDown(KeyCode.E) && Shellin == true && shellGrab.hasShell == false)
            {
                zoomFactor = 2;
                Player.speed = 0;
                OutsideTank.SetActive(true);
                inCam = true;
                AddAmmo();
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
     
    void AddAmmo()
    {
        tonkScript.Ammo = 1;
    }
    public void StartGame()
    {
        back.SetActive(false);
        zoomFactor = 2.5f;
        Soilder.enabled = true;
        Tank.enabled = true;
        Cam.enabled = true;
    }
}
