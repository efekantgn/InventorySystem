using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject CraftPanel;
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
    #endregion
}
