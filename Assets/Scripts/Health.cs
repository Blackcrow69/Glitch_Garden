using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;



    public void DealDamage (float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            //trigger death animation
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
