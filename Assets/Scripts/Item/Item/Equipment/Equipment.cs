using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    [SerializeField] private bool _isEquipped;

    public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }

    public override void UseItem()
    {
        if (!IsEquipped)
        {
            Debug.Log("equip");
            transform.SetParent(MainPanel.Instance.EquipedPanel.transform);
        }
        else
        {
            Debug.Log("unequip");
            transform.SetParent(MainPanel.Instance.BackpackPanel.transform);
        }
    }
}
