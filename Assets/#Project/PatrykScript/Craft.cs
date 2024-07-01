using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Craft : MonoBehaviour
{
    Resource r1,r2,r3;
    [SerializeField]List<Resource> ResourcesUtilisé;
    LivreRecette livreRecette;
    bool SomthingIsCraftable;
    Dictionary<Item,List<Resource>> Recettes;

    private void Start() 
    {
        RemplireLivreRecettes();
        livreRecette = new LivreRecette(Recettes);
        SomthingIsCraftable = false;
        //test
        Debug.Log(VerifyIfSomthingIsCraftable());
        //finTest
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "resource")
        {
            if(r1 != null)
            {
                r1 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r2 != null)
            {
                r2 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r3 != null)
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
                r1 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r2 == other.GetComponent<Resource>())
            {
                r2 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
            else if(r3 == other.GetComponent<Resource>())
            {
                r3 = other.GetComponent<Resource>();
                VerifyIfSomthingIsCraftable();
            }
        }
    }

    private bool VerifyIfSomthingIsCraftable()
    {
        if(r3==null && r2 != null && r1 != null)
        {
            if(livreRecette.Verify(r1,r2))
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
            if(livreRecette.Verify(r1,r3))
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
            if(livreRecette.Verify(r2,r3))
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
            if(livreRecette.Verify(r1,r2,r3))
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
        return SomthingIsCraftable;
    }


private void RemplireLivreRecettes()
{

}

}
