using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectInteraction : MonoBehaviour
{
    public Camera arCamera;
    public GameObject infoGraphic;

    
    public GameObject selectedARObject; // Das ausgewählte AR-Objekt

    // Für Highlighted Objects
    private Transform highlight;
    private Transform selection;
    private Outline outline;
    private RaycastHit raycastHit;   



    // Raycast Variabeln
    private Ray ray;
    private RaycastHit hit;      
                    

    private void Start()
    {
        arCamera = Camera.main;
        // Highlight aus
        outline = selectedARObject.GetComponent<Outline>();
        outline.enabled = false;  
    }

    private void Update()
    {
        ray = arCamera.ScreenPointToRay(Input.mousePosition);
        HighlightObject();
        //ShowMoreInfo();
        
          
    }

    void HighlightObject()
    {
        infoGraphic.transform.position = arCamera.WorldToScreenPoint(selectedARObject.transform.position);
                
        //Bei Mouse Over der Engine wird sie hervorgehoben

        // Überprüfe, ob Mauszeiger über einem GameObject liegt und ein Raycast (Strahl) ein anderes Objekt (hit) getroffen hat
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            highlight = hit.transform;
            // Wenn das getroffene Objekt den Tag “Engine” hat und nicht bereits ausgewählt ist 
            if (highlight.CompareTag("Engine") && highlight != selection)
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)  //Wenn Outline Komponente existiert
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true; //Aktiviere sie
                    // Zeige InfoGrafik
                    infoGraphic.GetComponent<ShowInfo>().ShowGetMoreInfo();
                    Debug.Log("Outline aktiv!");
                }
                else
                {
                    outline.enabled = true;
                    Debug.Log("Outline enabled");

                    // Zeige InfoGrafik
                    infoGraphic.GetComponent<ShowInfo>().ShowGetMoreInfo();
                }
            }
            else
            {
                // Wenn der Raycast kein Objekt trifft, setze das hervorgehobene Objekt auf null
                highlight = null;
                Debug.Log("Null");
            }
        } 

        else
        {
            outline.enabled = false;
        }


        
       
    }

     
     
     
     /*void ShowMoreInfo()
     {
    
        // Bei Klick auf die Engine soll die "Zeige mehr Infos" Grafik erscheinen
        
        if (Input.GetMouseButtonDown(0)) // Nutzer klickt auf den Bildschirm
        {       
            if (Physics.Raycast(ray, out hit))
            {

                // Prüfe, ob das getroffene Objekt das gewünschte Objekt ist
                if (hit.collider.CompareTag("Engine"))
                {
                    // Zeige die Grafik an oder führe andere Aktionen aus
                    infoGraphic.SetActive(true); 

                    
                    

                            
                }
            }  
        }
    } */

 
}
