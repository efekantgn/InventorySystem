using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    [SerializeField] private int _damage;

    public int Damage { get => _damage; set => _damage = value; }
}
