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
    [SerializeField]int dmg;

    [SerializeField]Material craftingMaterial;
    Material finalMaterial;

    Item(string nom,ItemType type)
    {
        this.nom = nom;
        this.type = type;
    }

    private void Start() {
        finalMaterial = transform.GetComponent<Renderer>().material;
        transform.GetComponent<Renderer>().material = craftingMaterial;
    }
}
