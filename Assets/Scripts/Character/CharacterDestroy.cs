using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterDestroy : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            // Destroy(this);
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");

            // this.gameObject.SetActive(false);
            //
        }
    }
}