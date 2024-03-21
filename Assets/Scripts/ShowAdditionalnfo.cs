using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Bei Mausklick auf das entsprechende Objekt (Engine) soll eine zusätzliche Info (Engine Anim) eingeblendet werden
public class ShowAdditionalnfo : MonoBehaviour
{
    public GameObject EngineInfo;
    public GameObject SimsonInfo;
    //public GameObject ObjectToInvestigate;  //Das Objekt, worüber ich zusätzliche Infos bekommen möchte
    public GameObject Engine; 
    public GameObject Simson;
    public GameObject icon; // Icon für mehr Infos verfügbar
    private GameObject iconclone;  // 2. Icon (Klon)
    private GameObject iconclone2;  // 3. Icon (Klon)
    private AudioSource Canvas_AudioSource; // Canvas beinhaltet Click Audioclip
   
    //public static string TagField;
    private Camera arCamera;
    //private bool isHovering;
    //private GameObject exitBtn;
    

    // Für Highlighted Objects
    private Transform highlight;  
    private Transform selection;
    private Outline outline;
 
    // Raycast Variabeln
    private Ray ray;
    private RaycastHit hit; 


    private GameObject Light;
    private bool LightIsOn;


    // Start is called before the first frame update
    void Start()
    {
        arCamera = Camera.main;
        ray = arCamera.ScreenPointToRay(Input.mousePosition);

        // Instanziere Clone des Icons als Kindobjekt des Canvas 
        iconclone = Instantiate(icon);
        iconclone.transform.SetParent(GameObject.Find("Canvas").transform, false);
        iconclone2 = Instantiate(icon);
        iconclone2.transform.SetParent(GameObject.Find("Canvas").transform, false);

        //Stelle sicher dass zu Beginn keine Panels Infos angezeigt werden
        EngineInfo.SetActive(false); 
        SimsonInfo.SetActive(false);

        Canvas_AudioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();

        Light = GameObject.Find("Light");
        LightIsOn = GameObject.Find("Light").GetComponent<ToggleLight>().ToggleLightOn();
    
    }

    // Update is called once per frame
    void Update()
    {
        ray = arCamera.ScreenPointToRay(Input.mousePosition);
        OnMouseKlickedObject();
        ShowIcons();  // Icon Pos muss immer wieder berechnet werden
        
    }


    // Wenn das Objekt angeklickt wird, soll je nach Tag das zugehörige InfoPanel angezeigt werden
    void OnMouseKlickedObject()
    {
        if((Input.GetMouseButtonDown(0)) && Physics.Raycast(ray, out hit))
        {   
            
            if (hit.collider.gameObject.name == "Engine")
            {
                EngineInfo.SetActive(true); 
                SimsonInfo.SetActive(false);
                Canvas_AudioSource.Play();
            }

            if ( hit.collider.gameObject.name == "Simson")
            {
                SimsonInfo.SetActive(true);
                EngineInfo.SetActive(false);
                Debug.Log("Maus klick auf Simson"  + hit.collider);
                Canvas_AudioSource.Play();
            }

            // Wenn Licht angeklickt wird, wird Licht eingeschaltet mittels des Skriptes auf dem Licht
            if (hit.collider.gameObject.name == "Light")
            {
                Light.GetComponent<ToggleLight>().ToggleLightOn(); 
                Canvas_AudioSource.Play();                                  
                               
            }  
        }
    }

    void ShowIcons()
    {
            
        //Positioniere Icons
        icon.transform.position = Camera.main.WorldToScreenPoint(Engine.transform.position);
        iconclone.transform.position = Camera.main.WorldToScreenPoint(Simson.transform.position);
        iconclone2.transform.position = Camera.main.WorldToScreenPoint(Light.transform.position);
        icon.SetActive(true);
        iconclone.SetActive(true); 
        iconclone2.SetActive(true);    
    }
}
 