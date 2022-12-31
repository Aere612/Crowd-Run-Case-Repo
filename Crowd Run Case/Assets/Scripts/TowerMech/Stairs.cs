using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human"))
        {
            other.transform.parent = null;
            Debug.Log("Girdi");

        }
    }
}
