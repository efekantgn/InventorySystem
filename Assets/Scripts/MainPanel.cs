using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject CraftPanel;

    public void ActivateSelectedPanel(string activePanel)
    {
        InventoryPanel.SetActive(activePanel.Equals(InventoryPanel.name));
        CraftPanel.SetActive(activePanel.Equals(CraftPanel.name));
    }

    public void OnInventoryButtonClicked()
    {
        ActivateSelectedPanel(InventoryPanel.name);
    }

    public void OnCraftButtonClicked()
    {
        ActivateSelectedPanel(CraftPanel.name);
    }
}
