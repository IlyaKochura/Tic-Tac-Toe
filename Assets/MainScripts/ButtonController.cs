using System;
using MechanicsGameS;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;



public class ButtonController : MonoBehaviour
{ 
    public Button button;
    public bool? Occupied = null;
    public Action Test { get; set;}
    
    public void Start()
    {
        button.onClick.AddListener( () => Test.Invoke());
    }

    public void ChangeText(string newText)
    {
        GetComponentInChildren<Text>().text = newText;
    }
}
