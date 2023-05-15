using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMonitor : MonoBehaviour
{
    public TextMeshProUGUI PocketList;
    public TextMeshProUGUI BackpackList;

    public Inventory Inventory;

    private void Update()
    {
        PocketList.text = "";
        BackpackList.text = "";

        foreach (var item in Inventory.PocketList)
        {
            PocketList.text += item.Name + "\n";
        }
        foreach (var item in Inventory.BackpackList)
        {
            BackpackList.text += item.Name + "\n";
        }
    }
}
