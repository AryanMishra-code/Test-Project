using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject prefab;
    public float damage;
    public float durability;
    public float attackSpeed;
    public WeaponType weaponType;
    public WeaponLevel weaponLevel;
}

public enum WeaponType { Melee, HarvestTool}
public enum WeaponLevel { Level1, Level2, Level3}