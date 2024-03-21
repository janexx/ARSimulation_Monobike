using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    public GameObject objectToRotate;
    public Button yourButton;
    public float rotationSpeed = 50f;
    private bool isRotating = false;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        isRotating = !isRotating; // Umschalten zwischen Drehen und Nicht-Drehen
    }

    void Update()
    {
        if (isRotating)
        {
            objectToRotate.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
}