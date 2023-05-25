using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : Item
{

    public override void UseItem()
    {
        MoveBetweenBackpackAndPocket();
    }

    public override void MoveItem(Transform targetParent)
    {
        transform.SetParent(targetParent);
    }
}
