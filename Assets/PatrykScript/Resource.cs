using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Minerals,Wood
}
public class Resource
{
    String nom;
    ResourceType type;
    //ont peut donner valeur en gold etc;

    Resource(String nom, ResourceType type)
    {
        this.nom = nom;
        this.type = type;
    }
}
