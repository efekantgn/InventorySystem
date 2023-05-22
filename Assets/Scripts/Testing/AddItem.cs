using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public GameObject[] itemPrefabList;

    public void AddRandomItem()
    {
        int random = Random.Range(0, itemPrefabList.Length);
        Inventory.Instance.AddItem(itemPrefabList[random],MainPanel.Instance.BackpackPanel.transform);

    }

    
    
}
