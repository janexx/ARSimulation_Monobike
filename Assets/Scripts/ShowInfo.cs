using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    public GameObject GetMoreInfoUI;
    public GameObject infoImage;  //Motoren GIF-Animation
    public Button closeBtn;
    private bool isKlicked = false;
    private Button btn;
    //private bool MoreInfoIsVisible = false;

   
    // Start is called before the first frame update
    void Start()
    {
        // Schaue, ob Info-Button geglickt wird
        btn = GetMoreInfoUI.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        //GIF ANimation wird noch nicht gezeigt
        infoImage.GetComponent<Image>().enabled=false;
        // Schließen-Button noch nicht sichtbar
        closeBtn.GetComponent<Image>().enabled=false;
        // Get More info noch nicht sichtbar
        HideGetMoreInfo();
    }

    // Update is called once per frame
    void Update()
    {
        // Bei Klick sollen Button und Image deaktiviert werden
        if(isKlicked)
        {
            HideGetMoreInfo();
            isKlicked = false;
            Debug.Log("Button deaktiviert");
        }


    }

    void TaskOnClick()
    {
        //Zeige GIF Animation und Schließen-Button
        infoImage.GetComponent<Image>().enabled=true;
        closeBtn.GetComponent<Image>().enabled=true;
        Debug.Log("Button geklickt"); 
        isKlicked=true;   


    }

    public void ShowGetMoreInfo()  // Button und Image aktivieren
    {
        GetMoreInfoUI.GetComponent<Button>().enabled = true;
        GetMoreInfoUI.GetComponent<Image>().enabled = true;
    }

    public void HideGetMoreInfo()  // Button und Image deaktivieren
    {
        GetMoreInfoUI.GetComponent<Button>().enabled = false;
        GetMoreInfoUI.GetComponent<Image>().enabled = false;
    }
}
