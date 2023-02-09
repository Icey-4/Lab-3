using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeak : damage
{
    public new void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "fire")
        {
            health = health - 40;
        }
    }
}
