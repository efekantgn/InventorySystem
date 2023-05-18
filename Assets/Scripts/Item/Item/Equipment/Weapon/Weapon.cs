using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    private int _damage;

    public int Damage { get => _damage; set => _damage = value; }
}
