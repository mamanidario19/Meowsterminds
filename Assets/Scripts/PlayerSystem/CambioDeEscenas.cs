using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioDeEscenas : MonoBehaviour
{
    public GameObject funciones;
    public void sceneChange(){
        
        SceneManager.LoadScene("SampleScene");
        funciones.GetComponent<SavePlayer>().Save();
    }
}
