using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public float Ammo;
    public FireCannon fire;

    void Start()
    {

    }

    void Update()
    {
        


        Ammo = Mathf.Clamp(Ammo, 0, 1);
    }

    
}