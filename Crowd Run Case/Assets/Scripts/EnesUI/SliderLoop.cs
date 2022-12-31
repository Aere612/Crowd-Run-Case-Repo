using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLoop : MonoBehaviour
{
    public Slider slider;
    public Text valueText;
    public bool Up = true;
    private void Awake()
    {
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    private void Update()
    {
        
        if (slider.value >= 1)
        {
            slider.value -= .4f * Time.deltaTime;
            Up = false;
        }
        else if ( slider.value<= 0 )
        {
            slider.value += 0.4f * Time.deltaTime;
            Up = true;
        }
        else if (Up)
        {
            slider.value += 0.4f * Time.deltaTime;
        }
        else
        {
            slider.value -= 0.4f * Time.deltaTime;
        }
    }

   
    void ValueChangeCheck()
    {   
        if (slider.value == 1)
        {
            Debug.Log("Slider deðeri 100'e ulaþtý.");
           
        }
        if (slider.value == 0)
        {
            Debug.Log("Slider deðeri 0'a ulaþtý.");
          
        }
    }
}
