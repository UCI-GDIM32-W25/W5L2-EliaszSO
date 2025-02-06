using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject {
    public string name;
    public string description;
    public Sprite icon;

    public void Use()
    {
        // use the item
    }
}