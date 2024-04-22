using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIDAssigner : MonoBehaviour
{
    [SerializeField] private int buttonID;

    private void Start()
    {
        // Asignar el ID al bot�n
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    private void OnClick()
    {
        // Enviar el ID al script que detecta el ID del bot�n
        ButtonIDDetector.instance.DetectButtonID(buttonID);
    }
}

