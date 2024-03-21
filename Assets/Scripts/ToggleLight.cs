using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleLight : MonoBehaviour
{
    public GameObject Licht; //Lichtkegel
    private bool lightisToggledOn=false;
    public Light spotlight; 
    

    private Ray ray;
    private RaycastHit hit;
    private Camera arCamera;

    // Start is called before the first frame update
    void Start()
    {
        arCamera = Camera.main;
        ray = arCamera.ScreenPointToRay(Input.mousePosition);

        lightisToggledOn=false;
        ToggleLightOn();

    }

    // Update is called once per frame
    void Update()
    {                  
        
    }

    public bool ToggleLightOn()
    {
        if(lightisToggledOn == false)
        {
            Licht.SetActive(true);
            spotlight.GetComponent<Light>().enabled = true;
            lightisToggledOn = true; 
            return lightisToggledOn;
        }

        if(lightisToggledOn == true)
        {
            Licht.SetActive(false);
            spotlight.GetComponent<Light>().enabled = false;
            lightisToggledOn = false;
            return lightisToggledOn;
        }
        else return false;        
       
    }

    public bool IsToggledOn()
    {
        return lightisToggledOn;
    }
}
