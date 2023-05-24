using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Unity.VisualScripting;
using TMPro;
using static UnityEngine.EventSystems.PointerEventData;

public class GUIItemMouseEvents : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject _generalPanel;
    private GameObject _usagePanel;

    private TextMeshProUGUI _infoPanelName;
    private TextMeshProUGUI _infoPanelDescription;
    private Item _item;
    private bool _mouseIsOver;
    [HideInInspector] private Transform _parentAfterDrag;
    [HideInInspector] private Transform _parentBeforeDrag;

    public GameObject GeneralPanel { get => _generalPanel; set => _generalPanel = value; }
    public GameObject UsagePanel { get => _usagePanel; set => _usagePanel = value; }
    public TextMeshProUGUI InfoPanelName { get => _infoPanelName; set => _infoPanelName = value; }
    public TextMeshProUGUI InfoPanelDescription { get => _infoPanelDescription; set => _infoPanelDescription = value; }
    public Item Item { get => _item; set => _item = value; }
    public Transform ParentAfterDrag { get => _parentAfterDrag; set => _parentAfterDrag = value; }
    public Transform ParentBeforeDrag { get => _parentBeforeDrag; set => _parentBeforeDrag = value; }
    public bool MouseIsOver { get => _mouseIsOver; set => _mouseIsOver = value; }



    #region UnityCallbacks
    private void Start()
    {
        Item = GetComponent<Item>();
        GeneralPanel = Item.GeneralPanel;
        UsagePanel = Item.UsagePanel;
        InfoPanelName = GameObject.Find("InfoPanelName").GetComponent<TextMeshProUGUI>();
        InfoPanelDescription = GameObject.Find("InfoPanelDescription").GetComponent<TextMeshProUGUI>();
    }
    #endregion

    #region PointerInterfaceCallbacks
    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (var item in Inventory.Instance.Items)
        {
            item.UsagePanel.SetActive(false);
        }
        if (eventData.button == InputButton.Right)
        {
            Item.SwitchGeneralUsagePanel();

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseIsOver = true;
        InfoPanelName.text = Item.ItemName;
        InfoPanelDescription.text = Item.ItemDescription;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        MouseIsOver = false;
        InfoPanelName.text = "";
        InfoPanelDescription.text = "";
    }
    
    #endregion


    #region DragInterfaceCallbacks
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        GetComponent<Button>().interactable = false;
        Item.IconPanel.GetComponent<Image>().raycastTarget = false;
        ParentBeforeDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        Item.IconPanel.GetComponent<Image>().raycastTarget = true;
        GetComponent<Button>().interactable = true;
    }


    #endregion
}