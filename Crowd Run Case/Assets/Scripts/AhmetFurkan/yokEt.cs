using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yokEt : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision col)
    {
    
        if (col.gameObject.tag == "engel")
        {
            Destroy(gameObject);
        }
    }
}
