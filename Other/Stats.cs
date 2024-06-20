using Godot;
using System;

public struct Stats 
{
    public float maxHp=1f;// {get;set;}//+
    public float defense=1f;// {get;set;}//+?
    public float speedMove=1f;// {get;set;}//+
    public float speedMult =1f;//{get;set;}//x
    public float damage=1f;//+
    public float damageMult=1f; //{get;set;}

    public Stats()
    {
    }


    public float size=1f;// {get;set;}//x
    public float speed=0f;// {get;set;}//+
    public float speedProjectileMult=1f;// {get;set;}//x
    public float count =0;//{get;set;}//+
    public float duration =5f;//{get;set;}//+
    public float durationMult=1f;// {get;set;}//x
    public float  expMult=1f;// {get;set;}//x
    public float fireRate =1f;//{get;set;}//x
    public int penetration =1;//{get;set;}//+
    public bool penetrationInf=false;// {get;set;}
    public float goldMult=1f;// {get;set;}//x
    public float cooldown=1f;//{get;set;}
    public static Stats operator *(Stats s1,Stats s2)
    {
        return new Stats{
            maxHp=s1.maxHp,
            speedMove=s1.speedMove,
            defense=s1.defense+s2.defense,
            count=s1.count+s2.count,
            duration=s1.duration,
            damage=s1.damage,
            penetrationInf=s1.penetrationInf,
            speed=s1.speed,
            damageMult=s1.damageMult*s2.damageMult,
            size=s1.size*s2.size,
            speedMult=s1.speedMult*s2.speedMult,
            goldMult=s1.goldMult*s2.goldMult,
            fireRate=s1.fireRate*s2.fireRate,
            speedProjectileMult=s1.speedProjectileMult*s2.speedProjectileMult,
            durationMult=s1.durationMult*s2.durationMult,
            expMult=s1.expMult*s2.expMult,
            cooldown=s1.cooldown
        };
    }
}
