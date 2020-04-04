using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text countdownText;

    [SerializeField] Text player1Score;
    [SerializeField] Text player2Score;

    [SerializeField] Text timerText;

    [SerializeField] GameObject resultPanel;
    [SerializeField] Text player1ResultScore;
    [SerializeField] Text player2ResultScore;
    [SerializeField] Text ResultPlayer;
    // Start is called before the first frame update
    void Start()
    {
        resultPanel.SetActive(false);
        StartCoroutine("Countdown");
    }

    // Update is called once per frame
    void Update()
    {
        switch (ShootingGameManager.Instance.GetNowState())
        {
            case ShootingGameManager.gameState.countdown:
                resultPanel.SetActive(false);
                break;
            case ShootingGameManager.gameState.gamePlaying:
                player1Score.text = ShootingGameManager.Instance.GetScore(1).ToString();
                player2Score.text = ShootingGameManager.Instance.GetScore(2).ToString();
                timerText.text = ShootingGameManager.Instance.GetTimer().ToString("F0");
                break;

            case ShootingGameManager.gameState.result:
                resultPanel.SetActive(true);
                player1ResultScore.text = ShootingGameManager.Instance.GetScore(1).ToString();
                player2ResultScore.text = ShootingGameManager.Instance.GetScore(2).ToString();
                ResultPlayer.text = "PLAYER" + ShootingGameManager.Instance.GetWinPlayer() + "Win!";
                break;
        }
        
        
    }


    IEnumerator Countdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.text = "Start!";
        yield return new WaitForSeconds(1f);
        countdownText.text = "";
        ShootingGameManager.Instance.ChangeNowState(ShootingGameManager.gameState.gamePlaying);

    }
}
