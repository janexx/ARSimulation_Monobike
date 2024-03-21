using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Der Nutzer soll mit Objekten in der Szene beim MouseOver interagieren können. 
Beispielsweise soll das Objekt mit dem Tag "Engine" hervorgehoben werden. Wenn die Maus das Objekt verlässt, soll die Hervorhebung deaktiviert werden. 
Dazu soll das Skript "Outline", welches auf dem zu interagierenden Objekt liegt, aktiviert und deaktiviert werden. 
Auf dem GameObject müssen das Skript "Outline" und "MaterialEmissionChanger" vorhanden sein. Außerdem wird ein Collider benötigt. */

public class NewHighlighter : MonoBehaviour
{
    public Outline outlineComponent;  // Outline Komponente (Skript) muss auf GameObject liegen
    private Outline currentOutline;    // Für aktuelle Outline, wenn mehrere existieren


    // Emission für Hover-Effekt (siehe EmissionChanger-Skript)
    private MaterialEmissionChanger emissionChanger;

    //private string tag;
    //private bool isBike;


    private void Start()
    {
        
        // Referenz auf das MaterialEmissionChanger-Skript erhalten
        emissionChanger = GetComponent<MaterialEmissionChanger>();
        emissionChanger.ResetEmission();        

        if (outlineComponent == null)
        {
            Debug.LogError("Outline-Skript nicht gefunden! Stelle sicher, dass es auf dem GameObject vorhanden ist.");
        }
        else
        {
            outlineComponent.enabled = false;
        }
    }

    private void Update()
    {
        // Erstelle einen Strahl von der Mausposition in die Szene
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Überprüfe, ob der Strahl ein Objekt trifft
        if (Physics.Raycast(ray, out hit))
        {   
            if (hit.collider.CompareTag("Selectable"))            
            {             

                // Aktiviere die Outline-Komponente des aktuellen Objekts
                currentOutline = hit.collider.GetComponent<Outline>();
                emissionChanger = hit.collider.GetComponent<MaterialEmissionChanger>();

                if (currentOutline != null)
                {
                    currentOutline.enabled = true;
                    emissionChanger.ChangeEmission();                                       
                }
            }
            else
            {
                // Deaktiviere die Outline-Komponente des vorherigen Objekts
                if (currentOutline != null)
                {
                    currentOutline.enabled = false;
                    emissionChanger.ResetEmission();                                       
                }
            }
        }

        
        else
        {
            if (currentOutline != null)
            {
                currentOutline.enabled = false;
                emissionChanger.ResetEmission();                                   
            }
        }
        
    }      

    
}
