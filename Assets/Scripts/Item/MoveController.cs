using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    public Slider Slider;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI NameText;
    public Item Item;


    public void OnSliderValueChanged()
    {
        CountText.text = (int)Slider.value + "";
    }

    public void OnClickConfirmButton()
    {
        //MoveItem Fonksiyonu eklenecek
        //Item.DropItem((int)Slider.value);
        MainPanel.Instance.DropPanel.SetActive(false);

    }

    public void OnClickCancelButton()
    {
        MainPanel.Instance.DropPanel.SetActive(false);
    }
}
