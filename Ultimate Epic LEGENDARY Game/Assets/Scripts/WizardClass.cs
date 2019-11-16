using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardClass : BaseClass
{
    private GameObject firePoint;
    public WizardClass()
    {
        ClassName = "Wizard";
        Health = 10;
        Strength = 5;
        Intelligent = 2;
        Agillity = 3;
        Damage = Strength * 5;
        Shooting = true;
    }

    public void Hit(ShootController prefab)
    {
        Instantiate(prefab, firePoint.transform.position, firePoint.transform.rotation);
    }

    public void Start()
    {
        firePoint = GameObject.Find("FirePoint");
    }

}
