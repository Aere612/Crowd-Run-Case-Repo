using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltayMovement : MonoBehaviour
{
    public void Move(Vector3 direction) // Ba�ka bir move class'�ndan �ekilmeli
    {
        transform.Translate(direction* 2 * Time.deltaTime);
    }
}
