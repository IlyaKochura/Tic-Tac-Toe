using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MechanicsGameS
{
    public class MechanicsGame : MonoBehaviour
    {
        [SerializeField] private List<ButtonController> _battleField;
        public static int _counter = 1;
        
        

        private void Start()
        {
            InvokeRepeating("CheckWin", 1, 1);
            
            for (var i = 0; i < _battleField.Count; i++)
            {
                int id = i;
                _battleField[i].Test = () => ButtonMove(id);
            }
        }

        private void Restart()
        {
            SceneManager.LoadScene(1);
        }

        private void ButtonMove(int index)
        {
            var but = _battleField[index];
            if (_battleField[index]._occupied == null)
            {
                if (_counter % 2 == 0)
                {
                    but.ChangeText("O");
                    _battleField[index]._occupied = true;
                }
                else
                {
                    but.ChangeText("X");
                    _battleField[index]._occupied = false;
                }
                _counter++;
            }
        }
    }
}
