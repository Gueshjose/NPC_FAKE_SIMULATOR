using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class LivreRecette
{
    List<Item> itemsInGame;
    Dictionary<List<Resource>,Item> Craftable;
    List<Resource> listR = new List<Resource>();
    Resource r1,r2,r3;
    Item CibleCrafting;

    public LivreRecette(Dictionary<List<Resource>,Item> Craftable)
    {
        this.Craftable =  Craftable;
    }

    public LivreRecette()
    {
        Craftable = new Dictionary<List<Resource>,Item>();
    }

    public Item Verify(Resource r1, Resource r2)
    {
        for(int i= 0;i < Craftable.Count;i++)
        {
            if(
                Craftable.Keys.ElementAt(i).Count <= 2 &&
                ((r1.nom == Craftable.Keys.ElementAt(i)[0].nom && r2.nom == Craftable.Keys.ElementAt(i)[1].nom)
              ||(r2.nom == Craftable.Keys.ElementAt(i)[0].nom && r1.nom == Craftable.Keys.ElementAt(i)[1].nom)))
            {
                Debug.Log(Craftable.Keys.ElementAt(i).Count);
                Debug.Log(Craftable.Keys.ElementAt(i).Count<2);
                return Craftable.Values.ElementAt(i);
            }
        }
        Debug.Log("Craftable.Keys.ElementAt(i).Count");
        Debug.Log("false");
        return null;
    }
    public Item Verify(Resource r1, Resource r2,Resource r3)
    {
        for(int i= 0;i < Craftable.Count;i++)
        {
            if(Craftable.Keys.ElementAt(i).Count > 2 && Craftable.Values.ElementAt(i) != null)
            {
                Debug.Log(Craftable.Keys.ElementAt(i)[0].nom);Debug.Log(Craftable.Keys.ElementAt(i)[1].nom);Debug.Log(Craftable.Keys.ElementAt(i)[2].nom);
                Debug.Log(r1.nom);Debug.Log(r2.nom);Debug.Log(r3.nom);
            if(
                  (r1.nom == Craftable.Keys.ElementAt(i)[0].nom && r2.nom == Craftable.Keys.ElementAt(i)[1].nom && r3.nom == Craftable.Keys.ElementAt(i)[2].nom)
                ||(r1.nom == Craftable.Keys.ElementAt(i)[0].nom && r3.nom == Craftable.Keys.ElementAt(i)[1].nom && r2.nom == Craftable.Keys.ElementAt(i)[2].nom)

                ||(r2.nom == Craftable.Keys.ElementAt(i)[0].nom && r1.nom == Craftable.Keys.ElementAt(i)[1].nom && r3.nom == Craftable.Keys.ElementAt(i)[2].nom)
                ||(r2.nom == Craftable.Keys.ElementAt(i)[0].nom && r3.nom == Craftable.Keys.ElementAt(i)[1].nom && r1.nom == Craftable.Keys.ElementAt(i)[2].nom)

                ||(r3.nom == Craftable.Keys.ElementAt(i)[0].nom && r1.nom == Craftable.Keys.ElementAt(i)[1].nom && r2.nom == Craftable.Keys.ElementAt(i)[2].nom)
                ||(r3.nom == Craftable.Keys.ElementAt(i)[0].nom && r2.nom == Craftable.Keys.ElementAt(i)[1].nom && r1.nom == Craftable.Keys.ElementAt(i)[2].nom)
            )
            {
                Debug.Log("true");
                Debug.Log(Craftable.Values.ElementAt(i).name);
                return Craftable.Values.ElementAt(i);
            }
            }
        }
        Debug.Log("false");
        return null;
    }

    public void addRecepies(Item CibleCrafting,List<Resource> listR)
    {
        Craftable.Add(listR,CibleCrafting);
    }

    public void addRecepies(Item CibleCrafting,Resource r1,Resource r2,Resource r3)
    {
        List<Resource> listR = new List<Resource>();
        listR.Add(r1);
        listR.Add(r2);
        listR.Add(r3);
        Craftable.Add(listR,CibleCrafting);
    }

    public void addRecepies(Item CibleCrafting,Resource r1,Resource r2)
    {
        List<Resource> listR = new List<Resource>();
        listR.Add(r1);
        listR.Add(r2);
        Craftable.Add(listR,CibleCrafting);
    }
}
