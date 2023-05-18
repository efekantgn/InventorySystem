using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    private bool _isEquipped;

    public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }

    public override void UseItem()
    {
        
            Debug.Log("a");

        if (!IsEquipped)
        {
            transform.SetParent(MainPanel.Instance.EquipedPanel.transform);
        }
    }
}
