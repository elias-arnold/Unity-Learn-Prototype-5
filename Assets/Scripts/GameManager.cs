using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Light light;

    
    private int score;
    private float spawnRate = 1f;
    private IEnumerator spawnNewElementCoroutine;

    private bool gameIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        updateScore(0);
        light.gameObject.SetActive(true);
        
        // gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(float difficulty)
    {
        
        if (!gameIsActive)
        {
            spawnRate = difficulty;
            score = 0;
            updateScore(0);
            spawnNewElementCoroutine = spawnNewElement();
            StartCoroutine(spawnNewElementCoroutine);
            gameIsActive = true;
        }
       
    }
    
    IEnumerator spawnNewElement()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);    
            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
        
// StartCoroutine(spawnNewElement());
    }

    public void updateScore(int addScore)
    {
        score += addScore;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameIsActive = false;
        StopCoroutine(spawnNewElementCoroutine);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
