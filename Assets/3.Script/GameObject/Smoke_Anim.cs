using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_Anim : MonoBehaviour
{
    public Object_Witch pot;
    public Animator anim;
    private void Awake()
    {
        pot = GetComponentInParent<Object_Witch>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
   
    }

    public void Bale_Smoke()
    {
        anim.SetBool("isMake", true);
    }
    public void Bale_Smoke_off()
    {
        anim.SetBool("isMake", false);
    }
    public void Sucess_Smoke()
    {
        anim.SetBool("isSucess", true);
        //Bale_Smoke_off();

    }
    public void Sucess_Smoke_Out()
    {
        anim.SetBool("isSucess", false);
        //Bale_Smoke_off();

    }
}
