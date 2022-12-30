using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool : MonoSingleton<ObjectPool>
{
    // Start is called before the first frame update
 [Serializable]
  public struct Pool 
    { 
        public Queue<GameObject> ObjPool; 
        public GameObject ObjPrefab; 
        public int ObjSize; 
    } 
    [SerializeField] private Pool[] Pools = null; 
    private void Awake() 
    { 
        for (int i = 0; i < Pools.Length; i++) 
        { 
           Pools[i].ObjPool = new Queue<GameObject>(); 
            for (int j = 0; j < Pools[i].ObjSize; j++) 
            { 
                GameObject obj = Instantiate(Pools[i].ObjPrefab); 
                obj.SetActive(false); 
                Pools[i].ObjPool.Enqueue(obj); 
            } 
        } 
    } 

    public GameObject GetPoolObj(int ObjType) 
    { 
        if (ObjType >= Pools.Length) 
            return null; 
        GameObject obj = Pools[ObjType].ObjPool.Dequeue(); 
        obj.SetActive(true); 
        Pools[ObjType].ObjPool.Enqueue(obj); 
        return obj; 
        
    } 
}
