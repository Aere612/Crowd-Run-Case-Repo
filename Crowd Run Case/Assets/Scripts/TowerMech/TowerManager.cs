using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class TowerManager : MonoBehaviour
{
    [SerializeField] int maxHumanPerRow;
    [SerializeField] float offsetBetweenHumans;
    
    List<int> rowCountList;
    List<GameObject> rowList;
    
    //CameraMovement camAnims;  // Kamera hareketleri için aþaðýda yorum satýrý içinde bulunan kamera kodlarý incelenebilir. Yapan kiþi cinemachine kullanýyordu.
    [HideInInspector] public bool canMove;

    private void Start()
    {
        rowCountList = new List<int>();
        rowList = new List<GameObject>();
        
        //camAnims = Camera.main.transform.parent.GetComponent<CameraMovement>();
        
        Build(); // FINISH ÇÝZGÝSÝNDEN GEÇÝNCE BU ÇALIÞMALI
    }
    void Update()
    {
        if (canMove)
        {
            transform.GetComponent<TowerMovement>().Move(Vector3.back); // SCENE KURGUSUNA BAÐLI OLARAK BU VEKTÖR DEÐÝÞMELÝ
        }
        
    }
    public void Build()
    {
        //BURADA KARAKTERLERÝN KENDÝ HAREKETLERÝ DURDURULMALI ÇÜNKÜ TOWER KENDÝ HAREKETÝNE BAÞLAYACAK
        //GetComponent<Movement>().CanMove = false;

        FillTowerList();
        StartCoroutine(BuildTowerCoroutine());
        
        //camAnims.EndGameAnim(towerList[0].transform);
    }
    void FillTowerList()
    {
        //int humanCount = GameManager.Instance.manCount;
        
        int humanCount = 50; // BU SATIRI KAPATIP ÜSTTEKÝ SATIRI AÇIN

        for (int i = 1; i <= maxHumanPerRow; i++)
        {
            if (humanCount < i)
                break;
            
            humanCount -= i;
            rowCountList.Add(i);
        }
        for (int i = maxHumanPerRow; i > 0; i--)
        {
            if (humanCount >= i)
            {
                humanCount -= i;
                rowCountList.Add(i);
                i++;
            }
        }
        rowCountList.Sort();
    }
    IEnumerator BuildTowerCoroutine()
    {
        int rowId = 0;
        Vector3 sum;
        GameObject row;
        float tempRowHumanCount;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

        foreach (int rowHumanCount in rowCountList)
        {
            foreach (GameObject child in rowList)
            {
                child.transform.localPosition += new Vector3(0,0.4f,0);
            }
            row = new GameObject("Row" + rowId);
            row.transform.parent = transform;
            row.transform.localPosition = new Vector3(0, 0.3f, 0);
            rowList.Add(row);
            sum = Vector3.zero;
            tempRowHumanCount = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.CompareTag("human"))
                {
                    //child.GetComponent<Movement>().CanMove = false;  //BU SATIRI AÇIN

                    child.transform.parent = row.transform;
                    child.transform.localPosition = new Vector3(tempRowHumanCount * offsetBetweenHumans, 0, 0);
                    
                    sum += child.transform.position;
                    tempRowHumanCount++;
                    i--;
                    
                    if (tempRowHumanCount >= rowHumanCount)
                        break;
                }
            }

            row.transform.position = new Vector3(-sum.x / rowHumanCount, row.transform.position.y, row.transform.position.z);
            sum = Vector3.zero;
            rowId++;
            
            yield return new WaitForSeconds(0.1f);
        }
        //GetComponent<Movement>().StartMovement(); // TOWER YAPILDIKTAN SONRA KARAKTERLÝN YÜRÜME ANÝMASYONU BURADAN BAÞLATILABÝLÝR.
        canMove = true;
    }
    
}