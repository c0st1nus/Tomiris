using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable, CreateAssetMenu(fileName = "New personage", menuName = "New Personage")]
public class Personage : ScriptableObject
{
    public new string name;
    public Sprite image;
}
