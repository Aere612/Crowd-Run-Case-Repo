using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject player;
    string a = "human";
    public void OnTriggerEnter(Collider other)
    {
        player.tag = a;
        TowerManager.Instance.Build();
    }
}
