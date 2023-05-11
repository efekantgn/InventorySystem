using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataPlacer : MonoBehaviour
{
    private Item _Item;

    public GameObject Icon;
    public GameObject Name;
    public GameObject Count;
    public GameObject Description;

    public void SetItem(Item item)
    {
        _Item= item;
    }
    public void SetUIElements()
    {
        Icon.GetComponent<Image>().sprite=_Item.Icon;
        Name.GetComponent<TextMeshProUGUI>().text = _Item.ObjectName;
        Count.GetComponent<TextMeshProUGUI>().text = _Item.Count+"";
        Description.GetComponent<TextMeshProUGUI>().text = _Item.Description;
    }

    
}
