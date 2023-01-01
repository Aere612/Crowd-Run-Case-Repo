using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHP = 100;
    public bool walk = true, kill = false ,canSwing=true;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
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
                //kill players
                kill = false;
                //counteri azalt
                bossHP -= 100;
            }
        }
    }
    public void Update()
    {

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
        //swing anim start
        yield return new WaitForSeconds(1f);
        kill=true;
        //swing anim end
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
