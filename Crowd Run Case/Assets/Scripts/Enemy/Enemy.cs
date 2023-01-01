using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    [SerializeField] float speed = 2;
    public EnemyManager manager;
    #endregion
    #region Unity Functions
    void FixedUpdate()
    {
        if(manager.attacking)
        {
            transform.LookAt(manager.player.transform.position);
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(other.gameObject);
            manager.amountOfEnemy--;
            Destroy(gameObject);
        }
    }
    #endregion
    ~Enemy()
    {
        manager.livingEnemy--;
    }

    
}
