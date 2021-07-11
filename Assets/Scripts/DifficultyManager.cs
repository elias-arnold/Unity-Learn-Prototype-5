using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public float difficulty;
    private Button button; 
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setDifficulty);
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDifficulty()
    {
        _gameManager.startGame(difficulty);
        GameObject.Find("Set Difficulty").gameObject.SetActive(false);
        Debug.Log("HEHO", button);
    }
}
