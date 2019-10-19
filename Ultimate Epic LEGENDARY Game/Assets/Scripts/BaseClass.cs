using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    private string className;
    private int health; 
    private int strength;
    private int intelligent;
    private int agillity;
    private int damage;
    private bool shooting;
    public string ClassName { get { return className; } set { className = value; } }
    public int Health { get { return health; } set { health = value; } }
    public int Strength { get { return strength; } set { strength = value; } }
    public int Intelligent { get { return intelligent; } set { intelligent = value; } }
    public int Agillity { get { return agillity; } set { agillity = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public bool Shooting { get { return shooting; } set { shooting = value; } }

}
