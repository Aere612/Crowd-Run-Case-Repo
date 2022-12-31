using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeMark : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true;
    }
}
