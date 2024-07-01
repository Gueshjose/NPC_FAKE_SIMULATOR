using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class LivreRecette
{
    List<Item> itemsInGame;
    Dictionary<Item,List<Resource>> Craftable;
    List<Resource> listR = new List<Resource>();
    Resource r1,r2,r3;
    Item CibleCrafting;

    public LivreRecette(Dictionary<Item,List<Resource>> Craftable)
    {
        this.Craftable =  Craftable;
    }

    public LivreRecette()
    {
        Craftable = new Dictionary<Item,List<Resource>>();
    }

    public bool Verify(Resource r1, Resource r2)
    {
        return true;
    }
    public bool Verify(Resource r1, Resource r2,Resource r3)
    {
        return true;
    }

    public void addRecepies(Item CibleCrafting,List<Resource> listR)
    {
        Craftable.Add(CibleCrafting,listR);
    }

    public void addRecepies(Item CibleCrafting,Resource r1,Resource r2,Resource r3)
    {
        List<Resource> listR = new List<Resource>();
        listR.Add(r1);
        listR.Add(r2);
        listR.Add(r3);
        Craftable.Add(CibleCrafting,listR);
    }

    public void addRecepies(Item CibleCrafting,Resource r1,Resource r2)
    {
        List<Resource> listR = new List<Resource>();
        listR.Add(r1);
        listR.Add(r2);
        Craftable.Add(CibleCrafting,listR);
    }
}
