using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public TankController tank;
    public FireCannon fire;
    Transform transform;
    private float shakeDuration = 0f;
    public float shakeMagnitude = 0.7f;
    public float time = 2.0f;
    public GameObject hatch;
    private float dampingSpeed = 1.0f;
    Vector3 initialPosition;
    public PlayerController player;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }

        if(fire.inCam == true && tank.Ammo >= 1)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                TriggerShake();
                fire.Shellin = false;
                tank.Ammo = 0;
                fire.Hatch.SetActive(false);
            }
        }
    }
    public void TriggerShake()
    {
        shakeDuration = time;
    }
}
