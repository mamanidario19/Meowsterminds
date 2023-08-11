/*
Este script maneja la destrucción del personaje controlado por el jugador al colisionar con un enemigo.
cuando ocurre la colisión, el personaje se desactiva y se carga la escena "GameOver".
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterDestroy : MonoBehaviour
{
    // Este metodo se llama cuando este objeto colisiona con otro objeto fisico.
    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Enemy") //Verifica si el objeto con el que colisionamos tiene la etiqueta "Enemy".
        {
            this.gameObject.SetActive(false); //DESACTIVA el GameObject actual (personaje controlado por el jugador)
            SceneManager.LoadScene("GameOver"); //Carga la escena correspondiente al sistema de derrota.
        }
    }
}