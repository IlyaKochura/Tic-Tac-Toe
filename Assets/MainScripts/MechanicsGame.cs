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
        
        [SerializeField] private int count = 3;
        [SerializeField] private GridLayoutGroup content;
        [SerializeField] private ButtonController prefab;
        public List<ButtonController> _battleField;
        [SerializeField] private GameObject _victoryInscription;
        [SerializeField] private RestartButton _restartButton;
        public static int _counter = 1;
        private bool _endGame = true;
        
        

        private void Start()
        {
            content.constraintCount = count;
            _battleField = new List<ButtonController>(count * count);
            
            for (var i = 0; i < count * count; i++)
            {
                var slot = Instantiate(prefab, content.transform);
                _battleField.Add(slot);
                int id = i;
                slot.Test = () => ClickButton(id);
            }
            _restartButton.Restart = () => Restart();
        }





        private void CheckWin()
        {
            for (int i = 0; i < count; i++)
            {
                var recordedCell = _battleField[i * count]._occupied;
                var recordedCell1 = _battleField[i]._occupied; // добавил
                if (recordedCell == null || recordedCell1 == null)
                {
                    continue;
                }

                bool isLine = true;
                bool isColumn = true;
                for (int g = 1; g < count; g++)
                {
                    if (recordedCell != _battleField[i * count + g]._occupied)
                    {
                        isLine = false;
                    }
                }

                for (int g = 1; g < count; g++)
                {
                    if (recordedCell1 != _battleField[i + g * count]._occupied)
                    {
                        isColumn = false;
                    }
                }

                if (isLine || isColumn)
                {
                    _endGame = false;
                    _victoryInscription.SetActive(true);
                    break;
                }
            }
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void ClickButton(int index)
        {
            var but = _battleField[index];
            if (_battleField[index]._occupied == null && _endGame)
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
                CheckWin();
            }
        }
    }
}
