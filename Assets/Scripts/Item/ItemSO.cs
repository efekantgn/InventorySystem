

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemSO :ScriptableObject
{
    public string ObjectName;
    public string Description;
    public bool Stackable;
    public int Count;
    public Sprite Icon;
}
