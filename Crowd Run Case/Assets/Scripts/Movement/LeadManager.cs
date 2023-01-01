using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeadManager : MonoBehaviour
{
    //HER SAHNEDE BI OBJEYE ATIN
    public static LeadManager Instance;

    bool isList;
    //liste üzerinden çalýþacaksa kullnan // initialize'dan deðistir
    List<Movement> movements;

    bool isInit = false;

    private void Awake() {
        Initialize();
    }
    void Initialize() {
        Instance = this;
        isList = true;
        if(isList)
            movements= new List<Movement>();
        isInit = true;
    }
    public void AddToList(Movement movement) {
        if (CheckList(movement))
            return;
        movements.Add(movement);
        FindLead();
    }
    //OYUNCU OLECEGI ZAMAN BUNU CAGIRMAYI UNUTMAYIN
    public void RemoveFromList(Movement movement) {
        if (!CheckList(movement))
            return;
        movements.Remove(movement);
        FindLead();
    }
    public bool CheckList(Movement movement) {
        return movements.Contains(movement)? true : false;
    }
    public void FindLead() {
        Vector3 vector3 = Vector3.zero;
        foreach (var item in movements) {
            SetLead(item, false, movements.Count);
            vector3 += item.transform.position;
        }
        vector3 /= movements.Count;
        float dist = 1000f;
        Movement closest = null;
        foreach (var item in movements)
            if (dist > Vector3.Distance(vector3, item.transform.position)) {
                dist = Vector3.Distance(vector3, item.transform.position);  
                closest = item;
            }
        if (closest != null)
            SetLead(closest, true, movements.Count);
        Debug.Log(closest);
    }
    public void SetLead(Movement movement, bool value, int count) {
        movement.SetIslead(value, movements.Count);
    }

}
