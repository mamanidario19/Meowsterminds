/*
Script encargado de habilitar en Project la creacion de nuevos Items ScriptableObjects
Ademas se define la estructura del ScriptableObject en el juego que puede ser recogido y almacenado en el inventario.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")] //Atributo para crear objetos desde el menu de Unity(Project).

public class Item : ScriptableObject //Creamos el registro de un item
{
    public int id; //atributo identificar unico de cada item.
    public string itemName; //Nombre de item.
    public int value; //futuro valor de comercio.
    public Sprite icon; //icono representativo de objeto.
    public Vector3 location; // Ubicacion en el escenario.
    public Quaternion rotation; // Rotacion en el escenario.
    public GameObject prefab; //Prefab (modelo) del objeto.
}