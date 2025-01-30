using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "ScriptableObject/EnityData")]
public class EntityData : InfoData
{
    [Header("Life")]
    public float hp = 100;

    [Header("Stats")]
    public float armor = 0;
}
