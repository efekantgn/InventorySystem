using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon",menuName = "Items/Weapon")]
public class Weapon : ItemSO
{
    public int weaponId;
    private void OnEnable()
    {
        WeaponId = weaponId;
    }


}
