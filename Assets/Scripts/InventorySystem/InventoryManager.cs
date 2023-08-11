/*Encargado del manejo de los items dentro del Inventario*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; //Instanciamos el objeto
    public List<Item> Items = new List<Item>(); //Creamos una nueva lista para los items recogidos 
    public Transform ItemContent; //obtenemos Data de ScriptableObjetc
    public GameObject InventoryItem; //obtenemos Data de ScriptableObjetc
    
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
        foreach (Transform item in ItemContent) // reinicia el inventario al ejecutar.
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items) // Vinculamos los valores, desde el scriptableObject a los componentes del inventario
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }


}
