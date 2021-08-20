using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter
{
    private string name;
    private int health;
    private int damage;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public void moveleft()
    {
        Debug.Log("gerak ke kiri");
    }
    public void moveright()
    {
        Debug.Log("gerak ke kanan");
    }
    public void jump()
    {
        Debug.Log("loncat");
    }
    public void atttack()
    {
        Debug.Log("serang");
    }
}
