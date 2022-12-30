using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltayMovement : MonoBehaviour
{
    public void Move(Vector3 direction) // Baþka bir move class'ýndan çekilmeli
    {
        transform.Translate(direction* 2 * Time.deltaTime);
    }
}
