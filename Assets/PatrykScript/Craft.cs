using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Craft : MonoBehaviour
{
    Resource r1,r2,r3;
    LivreRecette livreRecette;

    private void Start() 
    {
        livreRecette = new LivreRecette();
    }
}
