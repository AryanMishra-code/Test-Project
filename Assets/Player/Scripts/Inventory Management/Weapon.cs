using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    [Header("Weapon Properties")]
    public float damage;
    public float durability;
    public float attackSpeed;
}