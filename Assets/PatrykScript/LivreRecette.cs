using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class LivreRecette:MonoBehaviour
{
    [SerializeField]List<Item> itemsInGame;
    List<Dictionary<Item,List<Resource>>> Craftable;
    List<Resource> listR = new List<Resource>();
    Dictionary<Item,List<Resource>> Recette;
    Resource r1,r2,r3;
    Item CibleCrafting;

    public LivreRecette(List<Dictionary<Item,List<Resource>>> Craftable)
    {
        this.Craftable =  Craftable;
    }

    public LivreRecette()
    {
        Craftable = new List<Dictionary<Item,List<Resource>>>();
    }

    public void InitiateBook()
    {

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
        Dictionary<Item,List<Resource>> tempDic = new Dictionary<Item,List<Resource>>();
        tempDic.Add(CibleCrafting,listR);
        Craftable.Add(tempDic);
    }

    public void addRecepies(Dictionary<Item,List<Resource>> tempDic)
    {
        tempDic.Add(CibleCrafting,listR);
        Craftable.Add(tempDic);
    }

    public void addRecepies(Item CibleCrafting,Resource r1,Resource r2,Resource r3)
    {
        List<Resource> listR = new List<Resource>();
        Dictionary<Item,List<Resource>> tempDic = new Dictionary<Item,List<Resource>>();
        listR.Add(r1);
        listR.Add(r2);
        listR.Add(r3);
        tempDic.Add(CibleCrafting,listR);
        Craftable.Add(tempDic);
    }

    public void addRecepies(Item CibleCrafting,Resource r1,Resource r2)
    {
        List<Resource> listR = new List<Resource>();
        Dictionary<Item,List<Resource>> tempDic = new Dictionary<Item,List<Resource>>();
        listR.Add(r1);
        listR.Add(r2);
        tempDic.Add(CibleCrafting,listR);
        Craftable.Add(tempDic);
    }
}
