using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrizeMark : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true;
        other.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0.1f,1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f)),ForceMode.Impulse);
    }
}
