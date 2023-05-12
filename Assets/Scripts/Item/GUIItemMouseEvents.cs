using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Unity.VisualScripting;
using TMPro;
using static UnityEngine.EventSystems.PointerEventData;

public class GUIItemMouseEvents : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,IPointerExitHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public GameObject GeneralPanel;
    public GameObject UsagePanel;
    
    private TextMeshProUGUI _InfoPanelName;
    private TextMeshProUGUI _InfoPanelDescription;
    private ItemData _ItemData;
    private Item _Item;
    [HideInInspector]public Transform ParentAfterDrag;



    #region UnityCallbacks
    private void Start()
    {
        _Item = GetComponent<Item>();
        _ItemData = _Item.ItemData;
        _InfoPanelName = GameObject.Find("InfoPanelName").GetComponent<TextMeshProUGUI>();
        _InfoPanelDescription = GameObject.Find("InfoPanelDescription").GetComponent<TextMeshProUGUI>();
    }
    #endregion

    #region PointerInterfaceCallbacks
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == InputButton.Right)
        {
            SwitchGeneralUsagePanel();

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _InfoPanelName.text = _ItemData.Name;
        _InfoPanelDescription.text = _ItemData.Description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _InfoPanelName.text = "";
        _InfoPanelDescription.text = "";
    }

    #endregion

    #region ScriptFunctions
    public void SwitchGeneralUsagePanel()
    {
        GeneralPanel.SetActive(!GeneralPanel.activeSelf);
        UsagePanel.SetActive(!UsagePanel.activeSelf);
    }
    #endregion

    #region DragInterfaceCallbacks
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        GetComponent<Button>().interactable= false;
        ParentAfterDrag = transform.parent;
        transform.SetParent( transform.root);
        transform.SetAsLastSibling();
        _Item.Icon.GetComponent<Image>().raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position= Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        transform.SetParent( ParentAfterDrag);
        _Item.Icon.GetComponent<Image>().raycastTarget = true;
        GetComponent<Button>().interactable = true;
    }

    #endregion
}