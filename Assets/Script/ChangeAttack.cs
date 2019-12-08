using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAttack : MonoBehaviour
{
    public List<GameObject> ListAttack;
    // Start is called before the first frame update
    public void SwitchAttack()
    {
        GameObject currentObject = GameObject.Find("SpawnAttack").GetComponent<SpawnAttack>().Attack;
        int pos = 0;
        for (int i=0; i < ListAttack.Count; i++)
        {
            if (ListAttack[i] == currentObject)
            {
                pos = (i + 1) % ListAttack.Count;
            }
        }
        
        GameObject.Find("SpawnAttack").GetComponent<SpawnAttack>().Attack = ListAttack[pos];
    }
}
