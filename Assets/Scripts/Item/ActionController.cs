using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{

    private Slider _slider;
    private TextMeshProUGUI _countText;
    private TextMeshProUGUI _nameText;
    private Item _item;

    public Slider Slider { get => _slider; set => _slider = value; }
    public TextMeshProUGUI CountText { get => _countText; set => _countText = value; }
    public TextMeshProUGUI NameText { get => _nameText; set => _nameText = value; }
    public Item Item { get => _item; set => _item = value; }

    private void Awake()
    {
        Slider = GetComponentInChildren<Slider>();
        NameText = GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>();
        CountText = GameObject.Find("ItemCount").GetComponent<TextMeshProUGUI>();
    }

    public void OnSliderValueChanged()
    {
        CountText.text=(int)Slider.value+"";
    }

    public void OnClickConfirmButton()
    {
        
        Item.DropItem((int)Slider.value);
        MainPanel.Instance.DropPanel.SetActive(false);

    }

    public void OnClickCancelButton()
    {
        MainPanel.Instance.DropPanel.SetActive(false);
    }
}

