using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public int Id;
    public int Health;
    public int Attack;
    public bool Ranged;

    public Enemy(int id)
    {
        this.Id = id;
        Health = Random.Range(75, 150);
        Attack = Random.Range(1, 10);
        Ranged = Random.Range(0, 1) == 0 ? true : false;
    }

    public override string ToString()
    {
        string str = $"Health: {Health}\n";
        str += $"Attack: {Attack}\n";
        str += $"Ranged: {Ranged}\n";

        return str;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public bool TakeDamage(int damageValue)
    {
        if (IsDead()) return true;

        Health -= damageValue;

        if (Health < 0)
            Health = 0;

        return IsDead();
    }
}
