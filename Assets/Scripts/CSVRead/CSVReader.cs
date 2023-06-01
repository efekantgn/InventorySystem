using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using static UnityEditor.Progress;

public class CSVReader : MonoBehaviour
{
    [SerializeField]private TextAsset _craftingDatas;

    public TextAsset CraftingDatas { get => _craftingDatas; set => _craftingDatas = value; }

    private static CSVReader _instance;
    public static CSVReader Instance { get => _instance; set => _instance = value; }
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

    public void ReadCSV()
    {
        string[] data = CraftingDatas.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None );
        
        int tableSize=data.Length/5-1;

        //for (int i = 0; i < tableSize; i++)
        //{
        //    Debug.Log("Output: " + data[5*(i+1)]);
        //    Debug.Log("Input1: " + data[5*(i+1)+1]);
        //    Debug.Log("Input2: " + data[5*(i+1)+2]);
        //    Debug.Log("Input3: " + data[5*(i+1)+3]);
        //    Debug.Log("Input4: " + data[5*(i+1)+4]);
        //}

        for (int i = 0; i < tableSize; i++)
        {
            List<ItemData> itemDatas= new List<ItemData>();
            ItemData outputData = new ItemData();
            outputData.ItemID = int.Parse(data[5 * (i + 1) ]);
            ItemData inputData1 = new ItemData();
            inputData1.ItemID = int.Parse(data[5 * (i + 1) + 1]);
            itemDatas.Add(inputData1);
            ItemData inputData2 = new ItemData();
            inputData2.ItemID = int.Parse(data[5 * (i + 1) + 2]);
            itemDatas.Add(inputData2);
            ItemData inputData3 = new ItemData();
            inputData3.ItemID = int.Parse(data[5 * (i + 1) + 3]);
            itemDatas.Add(inputData3);
            ItemData inputData4 = new ItemData();
            inputData4.ItemID = int.Parse(data[5 * (i + 1) + 4]);
            itemDatas.Add(inputData4);
            //foreach (var item in itemDatas)
            //{
            //    if (item.ItemID != -1)
            //    {
            //        itemDatas.Add(item);
            //    }
            //}

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
}
