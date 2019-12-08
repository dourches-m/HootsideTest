using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : MonoBehaviour
{
    private Animator animator;
    public string Damage;
    public bool isHit;
    public string Dead;
    private int HitCount;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isHit = false;
        HitCount = 0;
    }

    void PlayDamage()
    {
        animator.Play(Damage);
        isHit = false;
        HitCount += 1;
    }

    void PlayDead()
    {
        animator.Play(Dead);
        HitCount = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isHit)
            PlayDamage();
        if (HitCount == 3)
            PlayDead();
    }
}
