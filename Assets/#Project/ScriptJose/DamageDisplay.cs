using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField]CollisionControl dummy;
    Animator anim;
    [SerializeField]TMP_Text DamageText;
    int previousDamage;
    // Start is called before the first frame update
    void Start()
    {
        previousDamage=dummy.damage;
        anim= GetComponent<Animator>();
       StartCoroutine("DisplayText"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator DisplayText()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (previousDamage != dummy.damage)
            {
                DamageText.SetText($"{dummy.damage}");
                previousDamage =dummy.damage;
                anim.Play("anim");
                yield return new WaitForSeconds(1f);
                DamageText.SetText("");

            }
        }
    }
}
