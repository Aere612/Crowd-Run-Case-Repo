using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("prize"))
            GameObject.Find("TowerManager").GetComponent<TowerManager>().canMove = false; // LEVELIN BÝTMESÝNÝ BURASI TETÝKLÝYOR.
    }
}
