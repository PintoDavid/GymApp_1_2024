using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonIDDetector : MonoBehaviour
{
    public static ButtonIDDetector instance;

    [SerializeField] private List<TextMeshProUGUI> textMeshPros = new List<TextMeshProUGUI>();

    [SerializeField] private List<string> nombreEjercicios = new List<string>(); // Lista de nombres de ejercicios para los elementos de textMeshPros
    [SerializeField] private List<string> descripcionEjercicios = new List<string>(); // Lista de descripciones de ejercicios para los elementos de textMeshPros
    [SerializeField] private List<string> lesionesEjercicios = new List<string>(); // Lista de lesiones de ejercicios para los elementos de textMeshPros

    private void Awake()
    {
        // Establecer el Singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DetectButtonID(int buttonID)
    {
        // Verificar si el ID del botón está dentro del rango válido
        if (buttonID >= 1)
        {
            // Obtener el índice del elemento correspondiente al ID del botón
            int index = buttonID - 1;

            // Asignar los textos a los TextMeshProUGUI basados en el ID del botón
            if (index < nombreEjercicios.Count)
            {
                textMeshPros[0].text = nombreEjercicios[index];
            }
            if (index < descripcionEjercicios.Count)
            {
                textMeshPros[1].text = descripcionEjercicios[index];
            }
            if (index < lesionesEjercicios.Count)
            {
                textMeshPros[2].text = lesionesEjercicios[index];
            }
        }
        else
        {
            Debug.LogWarning("El ID del botón está fuera del rango válido.");
        }
    }
}