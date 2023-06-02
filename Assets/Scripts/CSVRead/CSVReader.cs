using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using static UnityEditor.Progress;

public class CSVReader : MonoBehaviour
{
    [SerializeField]private TextAsset _craftingDatas;
    [SerializeField]private AddItem _addItem;

    public TextAsset CraftingDatas { get => _craftingDatas; set => _craftingDatas = value; }

    private static CSVReader _instance;
    public static CSVReader Instance { get => _instance; set => _instance = value; }
    public AddItem AddItem { get => _addItem; set => _addItem = value; }

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        //AddItem=FindObjectOfType<AddItem>();
    }

    public void ReadCSV()
    {
        
        string[] data = CraftingDatas.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None );
        
        int tableSize=data.Length/5-1;


        for (int i = 0; i < tableSize; i++)
        {
            List<ItemData> itemDatas= new List<ItemData>();
            //ItemData outputData = new ItemData();
            //outputData.ItemID = int.Parse(data[5 * (i + 1) ]);
            //ItemData inputData1 = new ItemData();
            //inputData1.ItemID = int.Parse(data[5 * (i + 1) + 1]);
            //itemDatas.Add(inputData1);
            //ItemData inputData2 = new ItemData();
            //inputData2.ItemID = int.Parse(data[5 * (i + 1) + 2]);
            //itemDatas.Add(inputData2);
            //ItemData inputData3 = new ItemData();
            //inputData3.ItemID = int.Parse(data[5 * (i + 1) + 3]);
            //itemDatas.Add(inputData3);
            //ItemData inputData4 = new ItemData();
            //inputData4.ItemID = int.Parse(data[5 * (i + 1) + 4]);
            //itemDatas.Add(inputData4);

            ItemData outputData = new ItemData();
            outputData.ItemName = data[5 * (i + 1)];
            outputData.ItemID = SetItemIDWithName(outputData.ItemName);

            ItemData inputData1 = new ItemData();
            inputData1.ItemName = data[5 * (i + 1) + 1];
            inputData1.ItemID = SetItemIDWithName(inputData1.ItemName);
            itemDatas.Add(inputData1);
            ItemData inputData2 = new ItemData();
            inputData2.ItemName = data[5 * (i + 1) + 2];
            inputData2.ItemID = SetItemIDWithName(inputData2.ItemName);
            itemDatas.Add(inputData2);
            ItemData inputData3 = new ItemData();
            inputData3.ItemName = data[5 * (i + 1) + 3];
            inputData3.ItemID = SetItemIDWithName(inputData3.ItemName);
            itemDatas.Add(inputData3);
            ItemData inputData4 = new ItemData();
            inputData4.ItemName = data[5 * (i + 1) + 4];
            inputData4.ItemID = SetItemIDWithName(inputData4.ItemName);
            itemDatas.Add(inputData4);

            Debug.Log(inputData1.ItemID);
            Debug.Log(inputData2.ItemID);
            Debug.Log(inputData3.ItemID);
            Debug.Log(inputData4.ItemID);





            int CraftingSize = 0;
            for (int j = 0; j < itemDatas.Count; j++)
            {
                if (itemDatas[j].ItemID != -1)
                {
                    CraftingSize++;
                }
            }

            switch (CraftingSize)
            {
                case 1:
                    CraftingManager.Instance.OneItemRecepies.Add(outputData, inputData1);
                    Debug.Log("1");
                    break;
                case 2:
                    Debug.Log("2");

                    CraftingManager.Instance.TwoItemRecepies.Add(outputData, itemDatas);
                    break;
                case 3:
                    
                    Debug.Log("3");
                    CraftingManager.Instance.ThreeItemRecepies.Add(outputData, itemDatas);
                    break;
                case 4:
                    Debug.Log("4");
                    CraftingManager.Instance.FourItemRecepies.Add(outputData, itemDatas);
                    break;
                default:
                    break;
            }
            
        }
    }


    public int SetItemIDWithName(string itemName)
    {
        for (int i = 0; i < AddItem.itemPrefabList.Length; i++)
        {
            if (AddItem.itemPrefabList[i].GetComponent<Item>().ItemName.Equals(itemName))
            {
                return AddItem.itemPrefabList[i].GetComponent<Item>().ItemID;
            }

        }
        return -1;

    }
}
