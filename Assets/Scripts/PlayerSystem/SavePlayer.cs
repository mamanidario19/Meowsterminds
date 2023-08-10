using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour

{
    public bool playerMarie;
    public bool playerOliver;
    //
    private void Awake() {
        playerMarie = PlayerPrefs.GetInt("MarieSelect") == 1;
        playerOliver = PlayerPrefs.GetInt("OliverSelect") == 1;
    }
    private void Update(){
        //pj por defecto
        if (playerMarie == false && playerOliver == false)
        {
            playerMarie = true;
        }
        /* playerMarie = PlayerPrefs.GetInt("MarieSelect") == 1;
        playerOliver = PlayerPrefs.GetInt("OliverSelect") == 1; */
    }

    public void Marie(){
        playerMarie = true;
        playerOliver = false;
        Save();
    }

    public void Oliver(){
        playerMarie = false;
        playerOliver = true;
        Save();
    }

    public void Save(){
        PlayerPrefs.SetInt("MarieSelect", playerMarie? 1:0); //guardamos
        PlayerPrefs.SetInt("OliverSelect", playerOliver? 1:0); //
    }
}
