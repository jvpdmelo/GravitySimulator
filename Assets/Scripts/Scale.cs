using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Scale : MonoBehaviour
{
    public TextMeshPro displayText;
    public bool mostrarPeso = true;

    private List<Rigidbody> objetosNaBalanca = new List<Rigidbody>();

    void Start()
    {
        AtualizarDisplay();
    }

    //Detecta quando um Objeto entra no Collider
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null && !objetosNaBalanca.Contains(rb))
        {
            objetosNaBalanca.Add(rb);
            AtualizarDisplay();
        }
    }

    //Detecta quando um Objeto sai do collider
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null && objetosNaBalanca.Contains(rb))
        {
            objetosNaBalanca.Remove(rb);
            AtualizarDisplay();
        }
    }

    //Atualiza o Display
    void AtualizarDisplay()
    {
        float massaTotal = 0f;

        /*Cria um loop para cada objeto dentro da balança, onde o valor de cada é somado
        e atribuido a variavel massaTotal*/
        foreach (Rigidbody rb in objetosNaBalanca)
        {
            massaTotal += rb.mass;
        }

        //Calcula o peso com base na gravidade atual e mostra do Display
        if (mostrarPeso)
        {
            float peso = massaTotal * Physics.gravity.magnitude;
            displayText.text = peso.ToString("F2") + " N";
        }

        //Define o valor quando a condição não está ativa
        else
        {
            displayText.text = massaTotal.ToString("F2") + " kg";
        }
    }
}