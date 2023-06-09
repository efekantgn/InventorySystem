using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainPanel : MonoBehaviour, IPointerClickHandler
{
    [Header("Inventory Panels")]
    public GameObject InventoryPanel;
    public GameObject EquipedPanel;
    public GameObject PocketPanel;
    public GameObject BackpackPanel;

    [Header("Craft Panels")]
    public GameObject CraftPanel;
    public GameObject MaterialSelectionPanel;

    [Header("Other Panels")]
    public GameObject DropPanel;


    public static MainPanel Instance;

    private void Awake()
    {
        if (Instance==null || Instance!=this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    #region ScriptFunctions
    public void ActivateSelectedPanel(string activePanel)
    {
        InventoryPanel.SetActive(activePanel.Equals(InventoryPanel.name));
        CraftPanel.SetActive(activePanel.Equals(CraftPanel.name));
    }
    #endregion

    #region UICallbacks
    public void OnInventoryButtonClicked()
    {
        ActivateSelectedPanel(InventoryPanel.name);
    }

    public void OnCraftButtonClicked()
    {
        ActivateSelectedPanel(CraftPanel.name);
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (var item in Inventory.Instance.Items)
        {
            item.UsagePanel.SetActive(false);
        }
    }
    #endregion
}
