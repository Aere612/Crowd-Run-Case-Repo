using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    public GameObject Settings;

    public void StartingGame()
    {
        Movement.Instance.CanMove = true;
    }
    public void SettingsOpen()
    {
        Settings.SetActive(true);
        object6.SetActive(false);
    }
    public void SettingsClose()
    {
        Settings.SetActive(false);
        object6.SetActive(true);
    }
    public void SetObject1Active()
    {
        object1.SetActive(true);
    }

    public void SetObject1Inactive()
    {
        object1.SetActive(false);
    }

    public void SetObject2Active()
    {
        object2.SetActive(true);
    }

    public void SetObject2Inactive()
    {
        object2.SetActive(false);
    }

    public void SetObject3Active()
    {
        object3.SetActive(true);
    }

    public void SetObject3Inactive()
    {
        object3.SetActive(false);
    }

    public void SetObject4Active()
    {
        object4.SetActive(true);
    }

    public void SetObject4Inactive()
    {
        object4.SetActive(false);
    }

    public void SetObject5Active()
    {
        object5.SetActive(true);
    }

    public void SetObject5Inactive()
    {
        object5.SetActive(false);
    }

    public void SetObject6Active()
    {
        object6.SetActive(true);
    }

    public void SetObject6Inactive()
    {
        object6.SetActive(false);
    }
}
