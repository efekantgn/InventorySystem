using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

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
            ItemData outputData = new ItemData();
            outputData.ItemID = int.Parse(data[5 * (i + 1) ]);
            ItemData inputData = new ItemData();
            inputData.ItemID = int.Parse(data[5 * (i + 1)+1]);
            CraftingManager.Instance.OneItemRecepies.Add(outputData, inputData);
        }
    }
}
