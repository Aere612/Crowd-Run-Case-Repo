using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrizeMark : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true; // BURAYA FARKLI �EYLER GELEB�L�R AN�AMSYONU TAM YAPAMADI�IM ���N GRAV�TY A�TIM
    }
}
