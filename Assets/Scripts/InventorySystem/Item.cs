/*Script encargado de habilitar en Project la creacion de nuevos Items ScriptableObjects*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")] //Permite visualizar nueva funcion al apretar 2do click en Project

public class Item : ScriptableObject //Creamos el registro de un item
{
    public int id; //atributo unico de cada item
    public string itemName; //Nombre de item
    public int value; //futuro valor de comercio
    public Sprite icon; //icono representativo de objeto

}
