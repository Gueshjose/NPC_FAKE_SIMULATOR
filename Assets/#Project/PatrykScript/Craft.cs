using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Craft : MonoBehaviour
{
    Resource r1,r2,r3;
    [SerializeField]List<GameObject> ResourcesUtilisé;
    [SerializeField]List<GameObject> ItemCraftable;
    LivreRecette livreRecette;
    bool SomthingIsCraftable;
    Dictionary<List<Resource>,Item > Recettes;
    Item toCraft;

    private void Start() 
    {
        Recettes = new Dictionary<List<Resource>,Item>();
        RemplireLivreRecettes();
        livreRecette = new LivreRecette(Recettes);
        SomthingIsCraftable = false;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if(other.tag == "resource")
        {
            if(r1 == null)
            {
                Debug.Log("r1");
                r1 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r2 == null)
            {
                Debug.Log("r2");
                r2 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r3 == null)
            {
                Debug.Log("r3");
                r3 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else
            {
                Debug.Log("Nop Trop des recoures sur la table");
            }
        }
        if(other.tag == "hammer")
        {
                CraftNewItem();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "resource")
        {
            if(r1 == other.GetComponent<Resource>())
            {
                r1 = null;
                VerifyIfSomthingIsCraftable();
            }
            else if(r2 == other.GetComponent<Resource>())
            {
                r2 = null;
                VerifyIfSomthingIsCraftable();
            }
            else if(r3 == other.GetComponent<Resource>())
            {
                r3 = null;
                VerifyIfSomthingIsCraftable();
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
                Debug.Log("c1");
                SomthingIsCraftable = true;
            }
            else
            {
                Debug.Log("c2");
                SomthingIsCraftable = false;
            }
        }
        else if(r2 == null && r1 != null && r3 != null)
        {
            if(toCraft = livreRecette.Verify(r1,r3))
            {
                Debug.Log("c3");
                SomthingIsCraftable = true;
            }
            else
            {
                Debug.Log("c4");
                SomthingIsCraftable = false;
            }
        }
        else if(r1 == null && r2 != null && r3 != null)
        {
            if(toCraft = livreRecette.Verify(r2,r3))
            {
                Debug.Log("c5");
                SomthingIsCraftable = true;
            }
            else
            {
                Debug.Log("c6");
                SomthingIsCraftable = false;
            }
        }
        else if(r1 != null && r2 != null && r3 != null)
        {
            if(toCraft = livreRecette.Verify(r1,r2,r3))
            {
                Debug.Log("c7");
                SomthingIsCraftable = true;
            }
            else
            {
                Debug.Log("c8");
                SomthingIsCraftable = false;
            }
        }
        else
        {
            Debug.Log("c9");
            SomthingIsCraftable = false;
        }
        Debug.Log(SomthingIsCraftable);
        return SomthingIsCraftable;
    }

    private void CraftNewItem()
    {
        if(SomthingIsCraftable)
        {
        if(r1 != null)
        Destroy(r1.gameObject);
        if(r2 != null)
        Destroy(r2.gameObject);
        if(r3 != null)
        Destroy(r3.gameObject);
        //GetComponent<AudioSource>().Play(0);
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
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[0].GetComponent<Item>());
    
    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[0].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[6].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[1].GetComponent<Item>());
    //Creation de l item

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[0].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[2].GetComponent<Item>());
    //Creation de l item
    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[0].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[3].GetComponent<Item>());
    //Creation de l item

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[4].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[5].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[3].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[3].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[6].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[6].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[6].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[7].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[8].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[6].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[6].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[9].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[10].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[11].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[3].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[4].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[12].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[3].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[3].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[13].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[1].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[14].GetComponent<Item>());

    ResourcePourRecette = new List<Resource>();
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[5].GetComponent<Resource>());
    ResourcePourRecette.Add(ResourcesUtilisé[7].GetComponent<Resource>());
    //Connection de l item a la liste
    Recettes.Add(ResourcePourRecette,ItemCraftable[15].GetComponent<Item>());



}

}
