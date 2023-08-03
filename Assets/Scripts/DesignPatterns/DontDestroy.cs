/* Esta clase la utilizaremos como un patr�n de dise�o Singleton para almacenar los datos y objetos que queremos pasar de una Escena a otra */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //M�todo que se ejecutar� primero antes de que el objeto y los datos se destruyan//
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}