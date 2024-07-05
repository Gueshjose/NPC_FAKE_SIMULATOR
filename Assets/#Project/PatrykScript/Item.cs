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
    float pourcent = -0.2f;

    Item(string nom,ItemType type)
    {
        this.nom = nom;
        this.type = type;
    }

    private void Start() {
        finalMaterial = transform.GetComponent<Renderer>().material;
        transform.GetComponent<Renderer>().material = craftingMaterial;
        craftingMaterial.SetFloat("_Pourcentage",pourcent);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="hammer")
        {
            if(pourcent < 0.7f)
            {
            pourcent += 0.2f;
            craftingMaterial.SetFloat("_Pourcentage",pourcent);
        }else
        {
            transform.GetComponent<Renderer>().material = finalMaterial;
        }
        
        }
    }
}
