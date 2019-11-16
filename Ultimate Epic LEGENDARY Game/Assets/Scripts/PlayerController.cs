using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //basic movements
    public float movementSpeed = 20f;
    public float jumpForce = 400f;
    public float horizontalMove;
    public bool jump = false;
    Rigidbody2D rb;

    //stats
    public string playerClass = "player";
    public int playerHP;
    public int playerStrength;
    public int playerIntelligent;
    public int playerAgility;
    public int playerDamage;

    //prefabs
    public GameObject sword_prefab;
    public GameObject staff_prefab;
    public ShootController fireBall_prefab;
    public ShootController granade_prefab;

    //fire point
    public Transform firePoint;

    public List<GameObject> weapons = new List<GameObject>();

    public void WarriorClass()
    {
        if (!GetComponent<WarriorClass>())
        {
            if (GetComponent<WizardClass>() || GetComponent<ArcherClass>())
            {
                Destroy(GetComponent<WizardClass>());
                Destroy(GetComponent<ArcherClass>());
            }
            var _class = gameObject.AddComponent<WarriorClass>();
            playerClass = _class.ClassName;
            playerHP = _class.Health;
            playerIntelligent = _class.Intelligent;
            playerAgility = _class.Agillity;
            playerDamage = _class.Damage;

            firePoint.localEulerAngles = new Vector3(0, 0, 0);

            if (weapons.Count == 1)
            {
                Destroy(weapons[0]);
                weapons.Remove(weapons[0]);
            }
            if (weapons.Count < 1)
            {
                weapons.Add(Instantiate(sword_prefab, transform, false));
                weapons[0].transform.position = new Vector2(transform.position.x, transform.position.y - 0.05f);
                weapons[0].gameObject.SetActive(true);
            }
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //moving 
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;
        //rotation
        if (horizontalMove < 0f)
            transform.localEulerAngles = new Vector3(0, 180, 0);


        if (horizontalMove > 0f)
            transform.localEulerAngles = new Vector3(0, 0, 0);

        //jumping
        if (Input.GetButtonDown("Jump"))
            jump = true;

        //attack
        if(Input.GetButtonDown("Fire1"))
        {
            if (GetComponent<WarriorClass>()) GetComponent<WarriorClass>().Hit();
            else if (GetComponent<ArcherClass>()) GetComponent<ArcherClass>().Hit(fireBall_prefab);
            else if (GetComponent<WizardClass>()) GetComponent<WizardClass>().Hit(granade_prefab);

        }
    }
    private void FixedUpdate()
    {
        Moving(horizontalMove, jump);
    }

    private void Moving(float movement, bool canJump)
    {
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if (canJump && GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = !canJump;
        }
    }
}
