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
        
        

        private void Start()
        {
            // for (var i = 0; i < _battleField.Count; i++)
            // {
            //     int id = i;
            //     _battleField[i].Test = () => ButtonMove(id);
            // }
            content.constraintCount = count;
            _battleField = new List<ButtonController>(count * count);
            
            for (var i = 0; i < count * count; i++)
            {
                var slot = Instantiate(prefab, content.transform);
                _battleField.Add(slot);
                int id = i;
                slot.Test = () => ClickButton(id);
            }
            //_restartButton.Restart = () => Restart();
        }
        
        
        
        

        private void CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                var recordedCell = _battleField[i * 3]._occupied;
                if (recordedCell == null)
                {
                    continue;
                }
                bool isLine = true;
                for (int g = 1; g < 3; g++)
                {
                    if (recordedCell != _battleField[i * 3 + g]._occupied)
                    {
                        isLine = false;
                    }
                }
                
                if (isLine)
                {
                    _victoryInscription.SetActive(true);
                    break;
                }
            }
            
            for (int h = 0; h < 3; h++)
            {
                var recordedCell1 = _battleField[h]._occupied; ;
                if (recordedCell1 == null)
                {
                    continue;
                }
                bool isLine1 = true;
                for (int g = 1; g < 3; g++)
                {
                    if (recordedCell1 != _battleField[h + g * 3]._occupied)
                    {
                        isLine1 = false;
                    }
                }
                if (isLine1)
                {
                    _victoryInscription.SetActive(true);
                    break;
                }
            }
            
            bool isLineDiagonal = true;
            var recordedCellDiagonal = _battleField[0]._occupied;
            if (recordedCellDiagonal != null)
            {
                for (int i = 1; i < 3; i++)
                {
                    if (recordedCellDiagonal != _battleField[i * 4]._occupied)
                    {
                        isLineDiagonal = false;
                        break;
                    }
                }
            }
            else
            {
                isLineDiagonal = false;
            }
            if (isLineDiagonal)
            {
                _victoryInscription.SetActive(true);
            }
            
            var recordedCellDiagonal1 = _battleField[2]._occupied;
            var isLineDiagonal1 = true;
            if (recordedCellDiagonal1 != null)
            {
                for (int i = 1; i < 3; i++)
                {
                    if (recordedCellDiagonal1 != _battleField[2 * i + 2]._occupied)
                    {
                        isLineDiagonal1 = false;
                        break;
                    }
                }
            }
            else
            {
                isLineDiagonal1 = false;
            }
            if (isLineDiagonal1)
            {
                _victoryInscription.SetActive(true);
            }
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void ClickButton(int index)
        {
            Debug.LogError(index);
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
                CheckWin();
            }
        }
    }
}
