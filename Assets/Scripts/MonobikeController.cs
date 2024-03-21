using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonobikeController : MonoBehaviour
{
    public GameObject objectToRotate;
    public Button yourButton;
    public float rotationSpeed = 50f;
    private bool isActive = false;  //Monobike ist aus
    //public Light spotlight; 
    //private GameObject lightbeam;
    public GameObject motorbike;
    private AudioSource bike_AudioSource;
    private Animation anim;    
    public GameObject smoke;
    private bool LightisOn;
    //private bool lightisToggledOn;



    void Start()
    {
        // Start-Button hört auf Klicks
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        // Audio aus
        bike_AudioSource = GameObject.Find("Engine").GetComponent<AudioSource>();
        bike_AudioSource.Stop();
        
        // Animation aus
        anim = motorbike.gameObject.GetComponent<Animation>();
        anim.Stop();
        //Smoke aus
        smoke.SetActive(false);
        Debug.Log("Monobike Controller startet");
        //Debug.Log();
       
    }

    void TaskOnClick()
    {
        
        Button btn = yourButton.GetComponent<Button>();      

        isActive = !isActive; // Umschalten zwischen an und aus
           
        if (isActive) //Wenn Monobike an ist
        {
            TurnBikeOn();
            //TurnLightOn(true);
            // ButtonLabel auf Stop setzen
            btn.GetComponent<ButtonLabelChanger>().SetButtonLabelStop();
            
        }
        else 
        {
            TurnBikeOff();
            //TurnLightOn(false);
            btn.GetComponent<ButtonLabelChanger>().SetButtonLabelStart();
        }

    }

 
    void Update()
    {
        // Rotiere Rad wenn Bike aktiv ist
        if (isActive)
        {
            objectToRotate.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }

    void TurnBikeOn()
    {
        anim.Play(); // Animation abspielen
        //music_Plays = true;
        bike_AudioSource.Play();
        smoke.SetActive(true);
        
        
    }

     void TurnBikeOff()
    {
        anim.Stop();
        bike_AudioSource.Stop();
        //music_Plays = false;
        smoke.SetActive(false);
        
    }   

   
}
