using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ButtonLabelChanger : MonoBehaviour
{
    //public TMP_FontAsset desiredFont; // Das gewünschte Schriftart-Asset
    //public Button MainButton;
    private TMP_Text buttonLabelText; // Das TextMeshPro-Element im Button

    void Start()
    {
        //MainButton.GetComponent<Button>;
        // Finde das TextMeshPro-Element im Button
        buttonLabelText = GetComponentInChildren<TMP_Text>();
    }

    public void SetButtonLabelStart()
    {
       // Ändere die Beschriftung des Buttons
      
        buttonLabelText.text = "Start";
    }

    public void SetButtonLabelStop()
    {
       // Ändere die Beschriftung des Buttons
      
        buttonLabelText.text = "Stop";
    }
       
    
}
