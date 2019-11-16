using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : BaseClass
{
    private Animator anim;
    public WarriorClass()
    {
        ClassName = "Warrior";
        Health = 10;
        Strength = 5;
        Intelligent = 2;
        Agillity = 3;
        Damage = Strength * 5;
        Shooting = false;
    }
    public void Hit()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("attack", false);
        StartCoroutine(HitSword());
    }

    private IEnumerator HitSword()
    {
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("attack", false);
    }
}
