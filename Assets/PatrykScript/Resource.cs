using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    LVMinerals,HVMinerals,Wood
}
public class Resource:MonoBehaviour
{
    [SerializeField]String nom;
    [SerializeField]ResourceType type;
    //ont peut donner valeur en gold etc;

    Resource(String nom, ResourceType type)
    {
        this.nom = nom;
        this.type = type;
    }
}
