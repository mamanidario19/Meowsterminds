using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Button btnIzquierda;
    [SerializeField] Button btnDerecha;
    [SerializeField] TextMeshProUGUI txtSelection;
    // Start is called before the first frame update
    [SerializeField] List<Transform> positionsCamera;

    //nose
    [SerializeField] List<string> playerNames;

    Transform cameraActualPos; //Pos actual de camara
    int posActual = 0;

    //camara
    Camera camera;


    private void Awake() {
        camera = Camera.main;
    }
    private void OnEnable() {
        //btnDerecha.onClick.AddListener(MoveSelectionLeft);
        btnDerecha.onClick.AddListener(MoveSelectionRight);
        
    }
    private void OnDisable() {
        //btnDerecha.onClick.AddListener(MoveSelectionLeft);
        btnDerecha.onClick.RemoveListener(MoveSelectionRight);
        
    }
   
    public void MoveSelectionLeft(){
        CameraMovementHandler(-1); //Manejador de mov de camara
        //CameraMovementHandler(0);
    }
    public void MoveSelectionRight(){
        CameraMovementHandler(1);
    }

    private void CameraMovementHandler(int i){

        posActual = posActual + i; 
        if (posActual < 0)//si las pos actual se le suma  1 
        {
            posActual = positionsCamera.Count - 1;
        }
        else if (posActual > positionsCamera.Count - 1)
        
        {
            posActual = 0;
            //posActual = 1;
        }
        cameraActualPos = positionsCamera[posActual];
        camera.transform.position = cameraActualPos.transform.position;
        txtSelection.text = playerNames[posActual];
    }

}
