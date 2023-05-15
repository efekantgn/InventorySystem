using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
   
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped.GetComponent<GUIItemMouseEvents>())
        {
            GUIItemMouseEvents item = dropped.GetComponent<GUIItemMouseEvents>();
            item.ParentAfterDrag = transform;
        }
    }

    
}
