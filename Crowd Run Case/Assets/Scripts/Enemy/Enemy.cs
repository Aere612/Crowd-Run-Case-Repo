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
            transform.LookAt(new Vector3(manager.player.transform.position.x , transform.position.y , manager.player.transform.position.z));
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.leadManager.RemoveFromList(other.gameObject.GetComponent<Movement>());
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
