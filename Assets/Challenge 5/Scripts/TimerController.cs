using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float countDown = 60f;
    private float counter = 0;

    public bool countdownIsActive = false;

    private GameManagerX _gameManagerX;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerX = GameObject.FindObjectOfType<GameManagerX>();
    }

    public void startCountdown()
    {
        counter = countDown;
        countdownIsActive = true;
    }
    public void stopCountdown()
    {
        countdownIsActive = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (counter > 0 && countdownIsActive)
        {
            counter -= Time.deltaTime;
        }

        if (counter <= 0 && countdownIsActive)
        {
            _gameManagerX.GameOver();
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = "Timer: " + (int) counter;
    }
}
