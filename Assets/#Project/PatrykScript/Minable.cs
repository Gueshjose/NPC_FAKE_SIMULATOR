using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Minable : MonoBehaviour
{
    [SerializeField]GameObject resourceDonné;
    [SerializeField]int inithp;
    int hp;
    float cd=0;
    [SerializeField]float maxCd;
    [SerializeField]GameObject toolsToMine;

    private void Start() {
        hp = inithp;
    }
    private void Update() 
    {
        if(cd > 0)
        {
            cd = cd - 0.1f;
        } 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other == toolsToMine && cd <= 0)
        {
            cd = maxCd;
            hp = hp -1;
        }
        if(hp <= 0)
        {
            hp = inithp;
            GiveRescource();
        } 
    }

    private void GiveRescource()
    {
        Instantiate(resourceDonné,new Vector3(transform.position.x,transform.position.y+1,transform.position.z), new Quaternion(0,0,0,0));
    }
}
