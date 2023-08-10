using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    public GameObject Marie;
    public GameObject Cubo;
    public bool playerMarie;
    public bool playerOliver;
   
    private void Update(){
        //carga esta info
        playerMarie = PlayerPrefs.GetInt("MarieSelect") == 1;
        playerOliver = PlayerPrefs.GetInt("OliverSelect") == 1;
    
        if (playerMarie == true)
        {
            Marie.SetActive(true);
            Debug.Log("Soy Marie");
            //Destroy(Cubo);
        }
        if (playerOliver == true)
        {
            Cubo.SetActive(true);
            Debug.Log("Soy Oliver");
            //Destroy(Marie);
        }

    }



}
