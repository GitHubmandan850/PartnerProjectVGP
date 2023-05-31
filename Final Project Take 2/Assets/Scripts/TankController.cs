using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public float Ammo;

    void Start()
    {

    }

    void Update()
    {
        Ammo = Mathf.Clamp(Ammo, -1, 1);
    }

    
}