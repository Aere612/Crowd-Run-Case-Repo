using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHP = 100;
    public bool walk = false, kill = false ,canSwing=true;
    public GameObject Player;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
        {
            GetComponent<Animator>().SetBool("isWalking",false);
            walk = false;
            if (canSwing)
            {
                canSwing = false;
                StartCoroutine(Swing());
            }
            if (kill)
            {
                Destroy(other.gameObject);
                kill = false;
                //counteri azalt
                bossHP -= 100;
            }
        }
    }
    public void Update()
    {
        if (Player.transform.position.z > 80)
        {
            walk = true;
        }
        if (walk)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            transform.Translate(new Vector3(0f, 0f, 0.01f));
        }
        if (bossHP <= 0)
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Swing()
    {
        GetComponent<Animator>().SetBool("isSwing", true);
        yield return new WaitForSeconds(1f);
        kill=true;
        GetComponent<Animator>().SetBool("isSwing", true);
        canSwing = true;
        yield return null;
    }
    IEnumerator Death()
    {
        GetComponent<Animator>().SetBool("isDead", true);
        yield return new WaitForSeconds(2f);
        //win
        Destroy(gameObject);
        yield return null;
    }
}