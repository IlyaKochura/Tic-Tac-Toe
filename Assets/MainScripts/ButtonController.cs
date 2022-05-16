using System;
using MechanicsGameS;
using UnityEngine;
using UnityEngine.UI;



public class ButtonController : MonoBehaviour
{
    public Button _button;
    public bool? _occupied = null;
    public Action Test { get; set;}
    
    public void Start()
    {
        _button.onClick.AddListener( () => Test.Invoke());
    }

    public void ChangeText(string newText)
    {
        GetComponentInChildren<Text>().text = newText;
    }
}
