using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    Animator anim;
    [SerializeField] int pvMax;
    public int damage =0;
     int pv;

     void Start()
     {
        anim=GetComponent<Animator>();
        pv=pvMax;
     }
    
    // Update is called once per frame

    void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<Item>())
        {
            
            damage = other.GetComponent<Item>().Damage();
            pv -= damage;
            if (pv <= 0)
            {
                anim.SetBool("Die",true);
            }
            anim.Play("pushed");
            StartCoroutine("RegenDummy");
        }
    }

    private IEnumerator RegenDummy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            anim.SetBool("Die",false);
            pv=pvMax;
        }
    }

}
