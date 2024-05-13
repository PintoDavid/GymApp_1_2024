using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValidacionDatosPerfil : MonoBehaviour
{
    public InputField inputField1;
    public InputField inputField2;
    public InputField inputField3;
    public Button boton;
    public TextMeshProUGUI mensajeError;
    public List<TextMeshProUGUI> textMeshPros;
    public List<InputField> inputsAsociados;

    private void Start()
    {
        // Agrega listeners para los eventos de cambio de texto en los InputFields
        inputField1.onValueChanged.AddListener(delegate { ValidarEntrada(); });
        inputField2.onValueChanged.AddListener(delegate { ValidarEntrada(); });
        inputField3.onValueChanged.AddListener(delegate { ValidarEntrada(); });

        // Configura el estado inicial del bot�n
        ValidarEntrada();
    }

    public void OnButtonClick()
    {
        // Verifica que todos los campos est�n llenos
        if (string.IsNullOrEmpty(inputField1.text) || string.IsNullOrEmpty(inputField2.text) || string.IsNullOrEmpty(inputField3.text))
        {
            mensajeError.text = "Debes llenar toda la informaci�n para continuar";
            return;
        }

        // Env�a la informaci�n de los InputFields a los TextMeshProUGUI asociados
        for (int i = 0; i < textMeshPros.Count; i++)
        {
            textMeshPros[i].text = inputsAsociados[i].text;
        }

        // Limpia el mensaje de error
        mensajeError.text = "";
    }

    private void ValidarEntrada()
    {
        // Activa o desactiva la interactividad del bot�n seg�n si los campos est�n llenos
        boton.interactable = !string.IsNullOrEmpty(inputField1.text) && !string.IsNullOrEmpty(inputField2.text) && !string.IsNullOrEmpty(inputField3.text);
    }
}
