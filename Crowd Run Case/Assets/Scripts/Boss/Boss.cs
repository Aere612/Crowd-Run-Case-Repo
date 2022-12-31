using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHP = 100;
    public bool walk = true, kill = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            walk = false;
            StartCoroutine(Swing());
            if (kill)
            {
                //kill players
                kill = false;
                bossHP -= 100;
            }
        }
    }
    
    public void Update()
    {
        if (walk)
        {
            //move forward
        }
        if (bossHP <= 0)
        {
            //death anim
            //game win
            //Gameobject.SetActive(false);
        }
    }
    IEnumerator Swing()
    {
        //swing anim start
        //yield return new WaitForSeconds(anim time/2);
        //kill=true;
        //swing anim end
        return null;
    }
}
