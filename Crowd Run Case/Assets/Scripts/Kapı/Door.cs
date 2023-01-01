using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{
   public int doorCount; 
   public GameObject otherDoor; //aktifliğini kapamak için
   public GameManager.Islem  doorIslem;

   [SerializeField] private TMP_Text doorCountText;
   [SerializeField] private TMP_Text doorTypeText;
   private void Start() {
    doorCountText.text=doorCount.ToString();
   switch (doorIslem) {
    case  GameManager.Islem.toplama:
        doorTypeText.text="+";
        break;
    case GameManager.Islem.carpma:
        doorTypeText.text="x";
        break;
    default :
        doorTypeText.text="+";
        break;
   }
    
   }
   
   private void OnTriggerEnter(Collider other) {
     Debug.Log("degdi");
    if(other.tag == "Player"){
        Debug.Log("degdi");
        if(doorIslem==GameManager.Islem.toplama){
            GameManager.Instance.manCount+=doorCount;
            for(int i = 0; i <doorCount ; i++) {
                var obj =ObjectPool.Instance.GetPoolObj(0);
                obj.transform.position=GameManager.Instance.Player.transform.position;
                obj.transform.parent=other.transform;
            }
              GameManager.Instance.FormatSticMan();
        }
        else if(doorIslem==GameManager.Islem.carpma){
          int tmp= GameManager.Instance.manCount; 
          GameManager.Instance.manCount*=doorCount;
            for(int i = 0; i <GameManager.Instance.manCount-tmp; i++) {
             var obj =ObjectPool.Instance.GetPoolObj(0);
                obj.transform.position=GameManager.Instance.Player.transform.position;  
                 obj.transform.parent=other.transform;
            }
              
              GameManager.Instance.FormatSticMan();
        }
        else{
            GameManager.Instance.manCount-=doorCount;
            for(int i = 0; i <doorCount ; i++) {
                
            }
        }
          //count UI değiştirilcek

      
    }
        GetComponent<BoxCollider>().enabled=false;
        otherDoor.GetComponent<BoxCollider>().enabled=false;
   }
}
