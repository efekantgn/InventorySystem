using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : EquipmentData
{
    private int _damage;

    public int Damage { get => _damage; set => _damage = value; }
}
