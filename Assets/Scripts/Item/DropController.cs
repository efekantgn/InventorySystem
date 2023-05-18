using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DropController : MonoBehaviour
{

    public Slider Slider;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI NameText;
    public Item Item;
    

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
