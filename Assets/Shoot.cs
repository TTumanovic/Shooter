using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Shooter
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}

//paveld
//poli
