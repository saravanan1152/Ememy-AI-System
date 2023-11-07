using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Effec1
{
    public GameObject CharacterEffect;
    public Transform CharacterAttachPoint;
    public float CharacterEffect_DestroyTime = 10;
    [Space]

    public GameObject CharacterEffect2;
    public Transform CharacterAttachPoint2;
    public float CharacterEffect2_DestroyTime = 10;
    [Space]

    public GameObject MainEffect;
    public Transform AttachPoint;
    public Transform OverrideAttachPointToTarget;
    public float Effect_DestroyTime = 10;
    [Space]

    public GameObject AdditionalEffect;
    public Transform AdditionalEffectAttachPoint;
    public float AdditionalEffect_DestroyTime = 10;

    [HideInInspector] public bool IsMobile;

}
[Serializable]
public class Effect2
{
    public GameObject CharacterEffect;
    public Transform CharacterAttachPoint;
    public float CharacterEffect_DestroyTime = 10;
    [Space]

    public GameObject CharacterEffect2;
    public Transform CharacterAttachPoint2;
    public float CharacterEffect2_DestroyTime = 10;
    [Space]

    public GameObject MainEffect;
    public Transform AttachPoint;
    public Transform OverrideAttachPointToTarget;
    public float Effect_DestroyTime = 10;
    [Space]

    public GameObject AdditionalEffect;
    public Transform AdditionalEffectAttachPoint;
    public float AdditionalEffect_DestroyTime = 10;

}



public class EffectsScript :MonoBehaviour
{
    public Effec1 effec1;
   
  public Effect2 effect2;

    public Abilites Abilites;
   
    private void Start()
    {
        Abilites = GetComponent<Abilites>();

    }
    private void Update()
    {
        if (Abilites.targetCircle.enabled==true)
        {
           effec1. AttachPoint.position = Abilites.targetCircle.transform.position;
        }
       
    }

    public void ActivateEffect()
    {

       
        if (effec1.MainEffect == null) return;
        GameObject instance;
        if (effec1.OverrideAttachPointToTarget == null) instance = Instantiate(effec1.MainEffect,effec1. AttachPoint.transform.position,effec1.AttachPoint.transform.rotation);
        else instance = Instantiate(effec1.MainEffect, effec1.AttachPoint.transform.position, Quaternion.LookRotation(-(effec1.AttachPoint.position - effec1.OverrideAttachPointToTarget.position)));
     
        if (effec1.Effect_DestroyTime > 0.01f) Destroy(instance, effec1.Effect_DestroyTime);
    }


  public void ActivateEffect1()
    {
        if (effect2.MainEffect == null) return;
        GameObject instance;
        if (effect2.OverrideAttachPointToTarget == null) instance = Instantiate(effect2.MainEffect, effect2.AttachPoint.transform.position, effect2.AttachPoint.transform.rotation);
        else instance = Instantiate(effect2.MainEffect, effect2.AttachPoint.transform.position, Quaternion.LookRotation(-(effect2.AttachPoint.position - effect2.OverrideAttachPointToTarget.position)));

        if (effect2.Effect_DestroyTime > 0.01f) Destroy(instance, effect2.Effect_DestroyTime);
    }
}
