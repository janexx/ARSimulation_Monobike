using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectHighlighter : MonoBehaviour
{
    private Transform highlight; // Das aktuell hervorgehobene Objekt
    private Outline outline; // Die Outline-Komponente des Objekts (falls vorhanden)

    private void Start()
    {
        // Annahme: Du hast bereits eine Outline-Komponente an diesem GameObject oder verwendest eine andere Methode zur Hervorhebung
        outline = GetComponent<Outline>();
        Debug.Log("ObjectHighlighter Start");
    }

    private void Update()
    {
        // Überprüfe, ob der Mauszeiger nicht über einem UI-Element liegt
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Erstelle einen Raycast vom Mauszeiger
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Wenn der Raycast ein Objekt trifft
            if (Physics.Raycast(ray, out hit))
            {
                // Wenn das getroffene Objekt den Tag "Engine" hat und nicht bereits ausgewählt ist
                if (hit.collider.CompareTag("Engine") && hit.transform != highlight)
                {
                    // Deaktiviere die Outline-Komponente des vorherigen Objekts (falls vorhanden)
                    if (highlight != null)
                    {
                        if (highlight.gameObject.GetComponent<Outline>() != null)
                        {
                            highlight.gameObject.GetComponent<Outline>().enabled = true;
                            Debug.Log("Outline aktiv");
                        }
                        else
                        {
                            outline.enabled = false;
                        }
                    }

                    // Setze das aktuell hervorgehobene Objekt
                    highlight = hit.transform;

                    // Aktiviere die Outline-Komponente des neuen Objekts (falls vorhanden)
                    if (highlight.gameObject.GetComponent<Outline>() != null)
                    {
                        highlight.gameObject.GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        outline.enabled = true;
                        Debug.Log("Outline aktiv");
                    }
                }
            }
            else
            {
                // Wenn der Raycast kein Objekt trifft, setze das hervorgehobene Objekt auf null
                highlight = null;
            }
        }

        else
        {
            if(highlight != null)
                highlight.gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}