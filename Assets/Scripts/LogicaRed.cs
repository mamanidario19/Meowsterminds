using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LogicaRed : MonoBehaviourPunCallbacks
{
    public static LogicaRed instancia; //

    void Awake()
    {
        instancia = this;
        DontDestroyOnLoad(gameObject); //Para q no se destruya entre escenas
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Felicidades estas conectado");
    }
}
