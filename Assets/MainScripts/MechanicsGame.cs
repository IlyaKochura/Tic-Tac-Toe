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
        [SerializeField] private GameObject victoryInscription;
        [SerializeField] private RestartButton _restartButton;
        [SerializeField] private GameObject _restartButtonPrefab;
        private List<ButtonController> _battleField;
        public static int _counter = 1;
        private bool _endGame = true;
        
        

        private void Start()
        {
            _restartButtonPrefab.SetActive(true);
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
                var recordedCell = _battleField[i * count].Occupied;
                if (recordedCell == null)
                {
                    continue;
                }
                bool isLine = true;
                for (int g = 1; g < count; g++)
                {
                    if (recordedCell != _battleField[i * count + g].Occupied)
                    {
                        isLine = false;
                    }
                }
                
                if (isLine)
                {
                    victoryInscription.SetActive(true);
                    _endGame = false;
                    break;
                }
            }
            
            for (int h = 0; h < count; h++)
            {
                var recordedCell1 = _battleField[h].Occupied; ;
                if (recordedCell1 == null)
                {
                    continue;
                }
                bool isLine1 = true;
                for (int g = 1; g < count; g++)
                {
                    if (recordedCell1 != _battleField[h + g * count].Occupied)
                    {
                        isLine1 = false;
                    }
                }
                if (isLine1)
                {
                    victoryInscription.SetActive(true);
                    _endGame = false;
                    break;
                }
            }
            
            bool isLineDiagonal = true;
            var recordedCellDiagonal = _battleField[0].Occupied;
            if (recordedCellDiagonal != null)
            {
                for (int i = 1; i < count; i++)
                {
                    if (recordedCellDiagonal != _battleField[i * (count + 1)].Occupied)
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
                victoryInscription.SetActive(true);
                _endGame = false;
            }
            
            var recordedCellDiagonal1 = _battleField[count -1].Occupied;
            var isLineDiagonal1 = true;
            if (recordedCellDiagonal1 != null)
            {
                for (int i = 1; i < count; i++)
                {
                    if (recordedCellDiagonal1 != _battleField[(count - 1) * i + (count - 1)].Occupied)
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
                victoryInscription.SetActive(true);
                _endGame = false;
            }
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void ClickButton(int index)
        {
            var but = _battleField[index];
            if (_battleField[index].Occupied == null && _endGame)
            {
                if (_counter % 2 == 0)
                {
                    but.ChangeText("O");
                    _battleField[index].Occupied = true;
                }
                else
                {
                    but.ChangeText("X");
                    _battleField[index].Occupied = false;
                }
                _counter++;
                CheckWin();
            }
        }
    }
}


//            for (int i = 0; i < count; i++)
//            {
//                 var recordedCell = _battleField[i * count]._occupied;
//                 var recordedCell1 = _battleField[i]._occupied; // добавил
//                 
//                 if (recordedCell == null || recordedCell1 == null)
//                 {
//                     continue;
//                 }
//
//                 bool isLine = true;
//                 bool isColumn = true;
//                 for (int g = 1; g < count; g++)
//                 {
//                     if (_battleField != null && recordedCell != _battleField[i * count + g]._occupied)
//                     {
//                         isLine = false;
//                     }
//                 }
//
//                 for (int g = 1; g < count; g++)
//                 {
//                     if (recordedCell1 != _battleField[i + g * count]._occupied)
//                     {
//                         isColumn = false;
//                     }
//                 }
//
//                 if (isLine || isColumn)
//                 {
//                     _endGame = false;
//                     _victoryInscription.SetActive(true);
//                     break;
//                 }
//             }
//
//             var isLineDiagonal = true;
//             var isLineReversDiagonal = true;
//             var recordedCellDiagonal = _battleField[0]._occupied;
//             var recordedCellReversDiagonal = _battleField[count - 1]._occupied;
//             if (recordedCellDiagonal != null)
//             {
//                 for (int i = 1; i < count; i++)
//                 {
//                     if (recordedCellDiagonal != _battleField[i * (count + 1)]._occupied)
//                     {
//                         isLineDiagonal = false;
//                         break;
//                     }
//                 }
//             }
//             else
//             {
//                 isLineDiagonal = false;
//             }
//             if (isLineDiagonal)
//             {
//                 _endGame = false;
//                 _victoryInscription.SetActive(true);
//             }
//             
//             if (recordedCellReversDiagonal != null)
//             {
//                 for (int i = 1; i < count; i++)
//                 {
//                     if (recordedCellReversDiagonal != _battleField[(count - 1) * i + (count - 1)]._occupied)
//                     {
//                         isLineReversDiagonal = false;
//                         break;
//                     }
//                 }
//             }
//             else
//             {
//                 isLineReversDiagonal = false;
//             }
//             if (isLineReversDiagonal)
//             {
//                 _endGame = false;
//                 _victoryInscription.SetActive(true);
//             }