using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionChanger : MonoBehaviour
{
    public GameObject[] objects; // Array der Objekte, deren Materialien geändert werden sollen
    public Color emissionColor = Color.white; // Die gewünschte Emissionsfarbe
    public float emissionIntensity = 1f; // Die Intensität der Emission

    private void Start()
    {
        ChangeEmission();
    }

    public void ChangeEmission()
    {
        foreach (GameObject obj in objects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                if (material != null)
                {
                    // Aktiviere die Emission des Materials
                    material.EnableKeyword("_EMISSION");

                    // Setze die Emissionsfarbe und -intensität
                    material.SetColor("_EmissionColor", emissionColor * emissionIntensity);
                }
            }
        }
    }

    public void ResetEmission()
    {
        foreach (GameObject obj in objects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                if (material != null)
                {
                    // Deaktiviere die Emission des Materials
                    material.DisableKeyword("_EMISSION");
                }
            }
        }
    }
}
