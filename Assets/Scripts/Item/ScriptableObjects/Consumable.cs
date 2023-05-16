using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable")]
public class Consumable : ItemSO
{
    public int consumableId;
    private void OnEnable()
    {
        ConsumableId = consumableId;
    }

}
