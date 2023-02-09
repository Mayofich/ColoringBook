using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTransit : MonoBehaviour
{

    public GameObject die;


    private void Start()
    {
        
    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().color = die.GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().sprite = die.GetComponent<SpriteRenderer>().sprite;
    }     

}
