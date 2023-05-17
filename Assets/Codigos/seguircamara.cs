using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguircamara : MonoBehaviour
{
    public Transform personaje;
    public float dondepersonaje;
    public float dondepersonajeY;
    
    
    

     private Movimiento personajeMovimiento;

    private void Awake()
    {
        GameObject personaje = GameObject.Find("Personaje"); // Sostituisci "NomeDellOggettoPersonaje" con il nome corretto dell'oggetto che ha lo script "movimiento"
        if (personaje != null)
        {
            personajeMovimiento = personaje.GetComponent<Movimiento>();
            if (personajeMovimiento == null)
            {
                Debug.LogError("L'oggetto personaje non ha lo script 'movimiento'. Assicurati che lo script 'movimiento' sia presente nell'oggetto personaje.");
            }
        }
        else
        {
            Debug.LogError("Impossibile trovare l'oggetto personaje nella scena. Assicurati che l'oggetto personaje sia presente nella scena con il nome corretto.");
        }
    }

    void Update()
    {
        if (personajeMovimiento != null)
        {
            float dondepersonaje = personajeMovimiento.transform.position.x;
            float dondepersonajeY = personajeMovimiento.transform.position.y;
            transform.position = new Vector3(dondepersonaje, dondepersonajeY, -10);
        }
    }
}
