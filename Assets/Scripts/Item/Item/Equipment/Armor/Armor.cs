using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    private int _armorResistance;

    public int ArmorResistance { get => _armorResistance; set => _armorResistance = value; }
}
