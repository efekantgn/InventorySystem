using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour, IDropHandler
{


    #region Interface
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped.GetComponent<GUIItemMouseEvents>())
        {
            Debug.Log("Drop");
            GUIItemMouseEvents GUIItemMouseEvent = dropped.GetComponent<GUIItemMouseEvents>();
            GUIItemMouseEvent.ParentAfterDrag = transform;
            GUIItemMouseEvent.Item.OldInventoryPanel = GUIItemMouseEvent.ParentBeforeDrag;
            if (transform==MainPanel.Instance.EquipedPanel.transform )
            {
                GUIItemMouseEvent.Item.UseItem();
            }
            else
            {
                GUIItemMouseEvent.Item.MoveItem(GUIItemMouseEvent.ParentAfterDrag);

            }
        }
    }

    #endregion
}
