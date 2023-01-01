using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{
    public void Move(Vector3 direction)
    {
        transform.Translate(direction* 2 * Time.deltaTime);
    }
}
