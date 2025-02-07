using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "ScriptableObjects/Enemy Stats", order = 1)]
public class EnemyStats : ScriptableObject {
    public string name;
    public float health;
    public float textDisplaySpeed = 2;
    public List<string> dialogueLine;
}