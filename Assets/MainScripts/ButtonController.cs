using System;
using MechanicsGameS;
using UnityEngine;
using UnityEngine.UI;



public class ButtonController : MonoBehaviour
{
    public MechanicsGame  _mechanicsGame;
    public Button _button;
    public bool? _occupied = null;

    private delegate void ButtonClicked(string x, string o);

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
