using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RedesDeJugador : MonoBehaviour
{
    private PhotonView photonView;
    public MonoBehaviour[] codigosQueIgnorar;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(!photonView.IsMine) //Si el objeto es falso
        {
            foreach(var codigo in codigosQueIgnorar){
                codigo.enabled = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
