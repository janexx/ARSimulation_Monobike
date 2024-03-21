using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems; 

public class PlaceBikeOnPlane : MonoBehaviour
{
    public GameObject objectToPlace;

    private ARRaycastManager raycastManager;
    private bool objectPlaced = false; // Wurde das Objekt bereits platziert?

    private void Awake()
    {
        // Ermöglicht das Raycasting in der AR-Szene, um den Boden zu erkennen
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Start()
    {
        // Platziere das Objekt auf dem Boden
        //PlaceObject();
    }

    private void Update()
    {
        if (!objectPlaced)
        {
            // Prüfe, ob eine Fläche erkannt wurde
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            // Sende Strahl vom Bildschirmzentrum aus und suche nach AR-Flächen (wie den Boden)
            raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

            if (hits.Count > 0)
            {
                Pose hitPose = hits[0].pose;
                Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                objectPlaced = true; // Markiere das Objekt als platziert
            }
        }
    }

    /*private void PlaceObject()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        // Sende Strahl vom Bildschirmzentrum aus und suche nach AR-Flächen (wie den Boden)
        raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        if (hits.Count > 0)
        {
            Pose hitPose = hits[0].pose;
            Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
        }
    
    } */
}
