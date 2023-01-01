using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrizeMark : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true; // BURAYA FARKLI ÞEYLER GELEBÝLÝR ANÝAMSYONU TAM YAPAMADIÐIM ÝÇÝN GRAVÝTY AÇTIM
    }
}
