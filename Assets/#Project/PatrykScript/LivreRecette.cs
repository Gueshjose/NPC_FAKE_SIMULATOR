using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public Item Verify(Resource r1, Resource r2)
    {
        for(int i= 0;i < Craftable.Count;i++)
        {
            if(
                (r1 == Craftable.Values.ElementAt(i)[0] && r2 == Craftable.Values.ElementAt(i)[1] || r2 == Craftable.Values.ElementAt(i)[2])
                ||(r2 == Craftable.Values.ElementAt(i)[0] && r1 == Craftable.Values.ElementAt(i)[1] || r1 == Craftable.Values.ElementAt(i)[2])
            )
            {
                return Craftable.Keys.ElementAt(i);
            }
        }
        return null;
    }
    public Item Verify(Resource r1, Resource r2,Resource r3)
    {
        for(int i= 0;i < Craftable.Count;i++)
        {
            if(
                (r1 == Craftable.Values.ElementAt(i)[0] && r2 == Craftable.Values.ElementAt(i)[1] && r3 == Craftable.Values.ElementAt(i)[2])
                ||(r1 == Craftable.Values.ElementAt(i)[0] && r3 == Craftable.Values.ElementAt(i)[1] && r2 == Craftable.Values.ElementAt(i)[2])

                ||(r2 == Craftable.Values.ElementAt(i)[0] && r1 == Craftable.Values.ElementAt(i)[1] && r3 == Craftable.Values.ElementAt(i)[2])
                ||(r2 == Craftable.Values.ElementAt(i)[0] && r3 == Craftable.Values.ElementAt(i)[1] && r1 == Craftable.Values.ElementAt(i)[2])

                ||(r3 == Craftable.Values.ElementAt(i)[0] && r1 == Craftable.Values.ElementAt(i)[1] && r2 == Craftable.Values.ElementAt(i)[2])
                ||(r3 == Craftable.Values.ElementAt(i)[0] && r2 == Craftable.Values.ElementAt(i)[1] && r1 == Craftable.Values.ElementAt(i)[2])
            )
            {
                return Craftable.Keys.ElementAt(i);
            }
        }
        return null;
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
