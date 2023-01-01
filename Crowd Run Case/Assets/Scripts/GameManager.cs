using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoSingleton<GameManager>
{
    public int manCount=1;
    public GameObject Player;
    
   [Range(0f,1f)] [SerializeField] private float distanceFactor,radius;
   public enum Islem{
        toplama,
        cıkarma,
        carpma
    }
    private void Start() {
        manCount=Player.transform.childCount+1;
    }
 public void FormatSticMan(){
    for(int i = 0; i < manCount-1; i++) {
        var x=distanceFactor *Mathf.Sqrt(i) *Mathf.Cos(radius*i);
        var z=distanceFactor *Mathf.Sqrt(i) *Mathf.Sin(radius*i);

        var newPos=new Vector3(x+1f,1f,z+1.8f);
        Player.transform.GetChild(i).DOLocalMove(newPos,1).SetEase(Ease.OutBack);
    }
 }
}
