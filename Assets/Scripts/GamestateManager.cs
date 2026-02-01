using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamestateManager : MonoBehaviour
{
    [SerializeField] 
    private PlayerDataBehavior _playerData;

    [SerializeField] 
    private int _victoryReputation;

    [SerializeField] 
    private int _defeatSuspicion;

    private void Start()
    {
        _playerData.OnStatusChanged += CheckVictory;
        _playerData.OnSuspicionChanged += CheckDefeat;
    }

    public void CheckVictory(int change, int total)
    {
        if (total >= _victoryReputation)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void CheckDefeat(int change, int total)
    {
        if (total >= _defeatSuspicion)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
