/* 
Este script administra el inventario en el juego, permitiendo agregar, remover y listar elementos en la interfaz de inventario
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; //Instanciamos el objeto
    public List<Item> Items = new List<Item>(); //Creamos una nueva lista para los items recogidos 
    public Transform ItemContent; // Referencia al contenedor de objetos en la interfaz de inventario.
    public GameObject InventoryItem; //ScriptableObjet que representa un objeto en la interfaz de inventario.
    private void Awake()
    {
        Instance = this;
    }
    /*Metodo que agrega un item a la lista*/
    public void Add(Item item)
    {
        Items.Add(item);
    }
    /*Metodo que remueve un item a la lista*/
    public void Remove(Item item)
    {
        Items.Remove(item);
    }
    /*Metodo que permite visualizar cada item en el inventario*/
    public void ListItems()
    {
        // reinicia el inventario al ejecutar.
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        // Crea objetos en la interfaz para cada elemento en la lista de objetos.
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemName.text = item.itemName; // Asigna el nombre del objeto al componente en el canvas.
            itemIcon.sprite = item.icon; // Asigna el icono del objeto al componente en el canvas.
        }
    }
}
