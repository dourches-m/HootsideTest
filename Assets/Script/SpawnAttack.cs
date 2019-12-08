using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAttack : MonoBehaviour
{
    public GameObject Attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("Skeleton@Skin").GetComponent<SkeletonAnimation>().isHit = true;
            Instantiate(Attack, transform.position, transform.rotation);
        }
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                GameObject.Find("Skeleton@Skin").GetComponent<SkeletonAnimation>().isHit = true;
                Instantiate(Attack, transform.position, transform.rotation);
            }
        } 
    }
}
