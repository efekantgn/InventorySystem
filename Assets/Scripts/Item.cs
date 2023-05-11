

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item :ScriptableObject
{
    public string ObjectName;
    public string Description;
    public int Count;
    public Sprite Icon;
}
