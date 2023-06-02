using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    [SerializeField] private int _healthRestoreAmount;
    [SerializeField] private int _manaRestoreAmount;
    [SerializeField] private int _staminaRestoreAmount;

    public int HealthRestoreAmount { get => _healthRestoreAmount; set => _healthRestoreAmount = value; }
    public int ManaRestoreAmount { get => _manaRestoreAmount; set => _manaRestoreAmount = value; }
    public int StaminaRestoreAmount { get => _staminaRestoreAmount; set => _staminaRestoreAmount = value; }

    public override void UseItem()
    {
        
        ConsumeItem();
    }

    public void ConsumeItem()
    {
        Debug.Log(HealthRestoreAmount+" HP restored.");
        Debug.Log(ManaRestoreAmount+" MP restored.");
        Debug.Log(StaminaRestoreAmount+" SP restored.");
        RemoveItem(1);
    }
    public override void MoveItem(Transform targetParent)
    {
        transform.SetParent(targetParent);
    }
}
