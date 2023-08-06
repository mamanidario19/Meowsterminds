using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour, IInteractable, IStorable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        print("Objeto conseguido");
        this.gameObject.SetActive(false);
    }

    public void Store()
    {

    }
}
