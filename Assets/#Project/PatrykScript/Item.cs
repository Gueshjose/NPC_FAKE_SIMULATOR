using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum ItemType
{
    Dager,Sword,Bow,Shield,Axe
}
public class Item:MonoBehaviour
{
    [SerializeField]string nom;
    [SerializeField]ItemType type;

    Item(string nom,ItemType type)
    {
        this.nom = nom;
        this.type = type;
    }
}
