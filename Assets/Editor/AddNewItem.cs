using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AddNewItem : EditorWindow
{

    private ItemType _itemType;
    private int _itemID;
    private string _itemName;
    private string _itemDescription;
    private bool _itemStackable;
    private int _itemCount;
    private Sprite _itemIcon;

    private int _weaponDamage;

    private int _armorResistance;

    private int _healthRestoreAmount;
    private int _manaRestoreAmount;
    private int _staminaRestoreAmount;



    public int ItemID { get => _itemID; set => _itemID = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public bool ItemStackable { get => _itemStackable; set => _itemStackable = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }
    public ItemType ItemType { get => _itemType; set => _itemType = value; }
    public int WeaponDamage { get => _weaponDamage; set => _weaponDamage = value; }
    public int ArmorResistance { get => _armorResistance; set => _armorResistance = value; }
    public int HealthRestoreAmount { get => _healthRestoreAmount; set => _healthRestoreAmount = value; }
    public int ManaRestoreAmount { get => _manaRestoreAmount; set => _manaRestoreAmount = value; }
    public int StaminaRestoreAmount { get => _staminaRestoreAmount; set => _staminaRestoreAmount = value; }

    [MenuItem("Window/Item/Add Item")]
    public static void ShowWindow()
    {
        GetWindow<AddNewItem>("Add New Item");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        ItemType=(ItemType)EditorGUILayout.EnumPopup("Select weapon type:", ItemType);
        ItemID=EditorGUILayout.IntField("ItemID:",ItemID);
        ItemName = EditorGUILayout.TextField("ItemName:",ItemName);
        ItemDescription = EditorGUILayout.TextField("ItemDescription:",ItemDescription);
        ItemStackable = EditorGUILayout.Toggle("Is Stackable Item?",ItemStackable);
        ItemCount = EditorGUILayout.IntField("ItemCount:", ItemCount);
        ItemIcon = (Sprite)EditorGUILayout.ObjectField("ItemIcon:", ItemIcon, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));

        switch (ItemType)
        {
            case ItemType.OneHandedWeapon:
                WeaponDamage = EditorGUILayout.IntField("Damage: ", WeaponDamage);
                
                break;
            case ItemType.TwoHandedWeapon:
                WeaponDamage = EditorGUILayout.IntField("Damage: ", WeaponDamage);

                break;
            case ItemType.OffHandWeapon:
                WeaponDamage = EditorGUILayout.IntField("Damage: ", WeaponDamage);

                break;
            case ItemType.HeadArmor:
                ArmorResistance = EditorGUILayout.IntField("Armor Resistance: ", ArmorResistance);
                break;
            case ItemType.BodyArmor:
                ArmorResistance = EditorGUILayout.IntField("Armor Resistance: ", ArmorResistance);
                break;
            case ItemType.FootArmor:
                ArmorResistance = EditorGUILayout.IntField("Armor Resistance: ", ArmorResistance);
                break;
            case ItemType.Consumable:
                HealthRestoreAmount = EditorGUILayout.IntField("Health Restore Amount: ", HealthRestoreAmount);
                ManaRestoreAmount = EditorGUILayout.IntField("Mana Restore Amount: ", ManaRestoreAmount);
                StaminaRestoreAmount = EditorGUILayout.IntField("Stamina Restore Amount: ", StaminaRestoreAmount);
                break;
            case ItemType.Material:
                break;
            default:
                break;
        }

        if (GUILayout.Button("Add Item"))
        {
            OnClickGenerateItemButton();
        }
        

    }

    public void OnClickGenerateItemButton()
    {
        GenerateItemPrefab();
    }

    public void GenerateItemPrefab()
    {
        switch (ItemType)
        {
            case ItemType.OneHandedWeapon:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Equipment/Weapon/IronSword.prefab", $"Assets/Prefabs/Equipment/Weapon/" + ItemName + ".prefab");
                Object OneHandedPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Equipment/Weapon/" + ItemName + ".prefab", typeof(GameObject));
                OneHanded oneHanded = OneHandedPrefab.GameObject().GetComponent<OneHanded>();
                SetItemDatas(oneHanded);

                break;
            case ItemType.TwoHandedWeapon:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Equipment/Weapon/IronHammer.prefab", $"Assets/Prefabs/Equipment/Weapon/" + ItemName + ".prefab");
                Object TwoHandedPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Equipment/Weapon/" + ItemName + ".prefab", typeof(GameObject));
                TwoHanded twoHanded = TwoHandedPrefab.GameObject().GetComponent<TwoHanded>();
                SetItemDatas(twoHanded);

                break;
            case ItemType.OffHandWeapon:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Equipment/Weapon/SpellBook.prefab", $"Assets/Prefabs/Equipment/Weapon/" + ItemName + ".prefab");
                Object OffHandPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Equipment/Weapon/" + ItemName + ".prefab", typeof(GameObject));
                OffHand offHand = OffHandPrefab.GameObject().GetComponent<OffHand>();
                SetItemDatas(offHand);
                break;
            case ItemType.HeadArmor:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Equipment/Armor/IronHelmet.prefab", $"Assets/Prefabs/Equipment/Armor/" + ItemName + ".prefab");
                Object HeadArmorPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Equipment/Armor/" + ItemName + ".prefab", typeof(GameObject));
                Head head = HeadArmorPrefab.GameObject().GetComponent<Head>();
                SetItemDatas(head);
                break;
            case ItemType.BodyArmor:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Equipment/Armor/IronChestPlate.prefab", $"Assets/Prefabs/Equipment/Armor/" + ItemName + ".prefab");
                Object BodyPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Equipment/Armor/" + ItemName + ".prefab", typeof(GameObject));
                Body body = BodyPrefab.GameObject().GetComponent<Body>();
                SetItemDatas(body);
                break;
            case ItemType.FootArmor:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Equipment/Armor/IronBoots.prefab", $"Assets/Prefabs/Equipment/Armor/" + ItemName + ".prefab");
                Object FootArmorPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Equipment/Armor/" + ItemName + ".prefab", typeof(GameObject));
                Foot foot = FootArmorPrefab.GameObject().GetComponent<Foot>();
                SetItemDatas(foot);
                break;
            case ItemType.Consumable:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Consumable/Apple.prefab", $"Assets/Prefabs/Consumable/" + ItemName + ".prefab");
                Object ConsumablePrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Consumable/" + ItemName + ".prefab", typeof(GameObject));
                Consumable consumable = ConsumablePrefab.GameObject().GetComponent<Consumable>();
                SetItemDatas(consumable);
                break;
            case ItemType.Material:
                AssetDatabase.CopyAsset($"Assets/Prefabs/Material/IronMaterial.prefab", $"Assets/Prefabs/Material/" + ItemName + ".prefab");
                Object MaterialPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Material/" + ItemName + ".prefab", typeof(GameObject));
                Material material = MaterialPrefab.GameObject().GetComponent<Material>();
                SetItemDatas(material);
                break;
            default:
                break;
        }
    }

    public void SetItemDatas(OneHanded oneHanded)
    {
        oneHanded.ItemID= ItemID;
        oneHanded.ItemName= ItemName;
        oneHanded.ItemDescription= ItemDescription;
        oneHanded.ItemStackable= ItemStackable;
        oneHanded.ItemCount= ItemCount;
        oneHanded.ItemIcon= ItemIcon;
        oneHanded.Damage= WeaponDamage;
    }
    public void SetItemDatas(TwoHanded twoHanded)
    {
        twoHanded.ItemID = ItemID;
        twoHanded.ItemName = ItemName;
        twoHanded.ItemDescription = ItemDescription;
        twoHanded.ItemStackable = ItemStackable;
        twoHanded.ItemCount = ItemCount;
        twoHanded.ItemIcon = ItemIcon;
        twoHanded.Damage = WeaponDamage;
    }
    public void SetItemDatas(OffHand offHand)
    {
        offHand.ItemID = ItemID;
        offHand.ItemName = ItemName;
        offHand.ItemDescription = ItemDescription;
        offHand.ItemStackable = ItemStackable;
        offHand.ItemCount = ItemCount;
        offHand.ItemIcon = ItemIcon;
        offHand.Damage = WeaponDamage;
    }
    public void SetItemDatas(Head head)
    {
        head.ItemID = ItemID;
        head.ItemName = ItemName;
        head.ItemDescription = ItemDescription;
        head.ItemStackable = ItemStackable;
        head.ItemCount = ItemCount;
        head.ItemIcon = ItemIcon;
        head.ArmorResistance = ArmorResistance;
    }
    public void SetItemDatas(Body body)
    {
        body.ItemID = ItemID;
        body.ItemName = ItemName;
        body.ItemDescription = ItemDescription;
        body.ItemStackable = ItemStackable;
        body.ItemCount = ItemCount;
        body.ItemIcon = ItemIcon;
        body.ArmorResistance = ArmorResistance;
    }
    public void SetItemDatas(Foot foot)
    {
        foot.ItemID = ItemID;
        foot.ItemName = ItemName;
        foot.ItemDescription = ItemDescription;
        foot.ItemStackable = ItemStackable;
        foot.ItemCount = ItemCount;
        foot.ItemIcon = ItemIcon;
        foot.ArmorResistance = ArmorResistance;
    }
    public void SetItemDatas(Consumable consumable)
    {
        consumable.ItemID = ItemID;
        consumable.ItemName = ItemName;
        consumable.ItemDescription = ItemDescription;
        consumable.ItemStackable = ItemStackable;
        consumable.ItemCount = ItemCount;
        consumable.ItemIcon = ItemIcon;
        consumable.HealthRestoreAmount= HealthRestoreAmount;
        consumable.ManaRestoreAmount= ManaRestoreAmount;
        consumable.StaminaRestoreAmount= StaminaRestoreAmount;
    }
    public void SetItemDatas(Material material)
    {
        material.ItemID = ItemID;
        material.ItemName = ItemName;
        material.ItemDescription = ItemDescription;
        material.ItemStackable = ItemStackable;
        material.ItemCount = ItemCount;
        material.ItemIcon = ItemIcon;
    }
}

public enum ItemType
{
    OneHandedWeapon,
    TwoHandedWeapon,
    OffHandWeapon, 
    HeadArmor,
    BodyArmor,
    FootArmor,
    Consumable,
    Material,
}
