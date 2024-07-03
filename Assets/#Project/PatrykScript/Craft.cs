using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Craft : MonoBehaviour
{
    Resource r1,r2,r3;
    [SerializeField]List<GameObject> ResourcesUtilisé;
    [SerializeField]List<GameObject> ItemCraftable;
    LivreRecette livreRecette;
    bool SomthingIsCraftable;
    Dictionary<Item,List<Resource>> Recettes;
    Item toCraft;

    private void Start() 
    {
        Recettes = new Dictionary<Item, List<Resource>>();
        RemplireLivreRecettes();
        livreRecette = new LivreRecette(Recettes);
        SomthingIsCraftable = false;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if(other.tag == "resource")
        {
            if(r1 == null)
            {
                r1 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r2 == null)
            {
                r2 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r3 == null)
            {
                r3 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else
            {
                Debug.Log("Nop Trop des recoures sur la table");
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "resource")
        {
            if(r1 == other.GetComponent<Resource>())
            {
                r1 = null;
            }
            else if(r2 == other.GetComponent<Resource>())
            {
                r2 = null;
            }
            else if(r3 == other.GetComponent<Resource>())
            {
                r3 = null;
            }
        }
    }

    private bool VerifyIfSomthingIsCraftable()
    {
        Debug.Log("VerifyIfSomthingIsCraftable()");
        if(r3==null && r2 != null && r1 != null)
        {
            if(toCraft = livreRecette.Verify(r1,r2))
            {
                SomthingIsCraftable = true;
            }
            else
            {
                SomthingIsCraftable = false;
            }
        }
        else if(r2 == null && r1 != null && r3 != null)
        {
            if(toCraft = livreRecette.Verify(r1,r3))
            {
                SomthingIsCraftable = true;
            }
            else
            {
                SomthingIsCraftable = false;
            }
        }
        else if(r1 == null && r2 != null && r3 != null)
        {
            if(toCraft = livreRecette.Verify(r2,r3))
            {
                SomthingIsCraftable = true;
            }
            else
            {
                SomthingIsCraftable = false;
            }
        }
        else if(r1 != null && r2 != null && r3 != null)
        {
            if(toCraft = livreRecette.Verify(r1,r2,r3))
            {
                SomthingIsCraftable = true;
            }
            else
            {
                SomthingIsCraftable = false;
            }
        }
        else
        {
            SomthingIsCraftable = false;
        }
        CraftNewItem();
        return SomthingIsCraftable;
    }

    private void CraftNewItem()
    {
        Debug.Log("CraftNewItem");
        if(SomthingIsCraftable)
        {
        Debug.Log(r1.gameObject +""+ r2.gameObject +""+ r3.gameObject);
        Destroy(r1.gameObject);
        Destroy(r2.gameObject);
        Destroy(r3.gameObject);
        Instantiate(toCraft,new Vector3(transform.position.x,transform.position.y+1,transform.position.z), new Quaternion(0,0,0,0));
        SomthingIsCraftable = false;
        toCraft = null;
        }
    }

    private void RemplireLivreRecettes()
{
    //ResourcesUtilisé;
    //ItemCraftable;
    List<Resource> ResourcePourRecette;
    ResourcePourRecette = new List<Resource>();

    //Ajout de materiaux dans une liste
    ResourcePourRecette.Add(ResourcesUtilisé[0].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[2].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ItemCraftable[0].GetComponent<Item>(),ResourcePourRecette);
    //Creation de l item
    //Instantiate(ItemCraftable[0],new Vector3(transform.position.x,transform.position.y+1,transform.position.z), new Quaternion(0,0,0,0));
}

}
