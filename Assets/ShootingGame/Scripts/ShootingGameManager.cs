using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameManager : SingletonMonoBehaviour<ShootingGameManager>
{
    int player1Score, player2Score;
    int winPlayer;

    public enum gameState {countdown,gamePlaying,result };
    gameState nowState;
    float gameTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        gameTimer = 6;
        nowState = gameState.countdown;
    }


    // Update is called once per frame
    void Update()
    {
        if(nowState == gameState.gamePlaying)
        {
            gameTimer -= Time.deltaTime;
            
            if (gameTimer <= 0)
            {
                nowState = gameState.result;
                DecideWinPlayer();
            }
        }
        
    }



    public void ChangeNowState(gameState state)
    {
        nowState = state;
    }

    public gameState GetNowState()
    {
        return nowState;
    }



    public float GetTimer()
    {
        return gameTimer;
    }



    public void ChangeScore(int player)
    {
        switch (player)
        {
            case 1:
                player1Score++;
                break;
            case 2:
                player2Score++;
                break;

        }
        
    }

    public int GetScore(int player)
    {
        int score;
        
        switch (player)
        {
            case 1:
                score = player1Score;
                Debug.Log(score);
                break;
            case 2:
                score = player2Score;
                break;
            default:
                score = 0;
                break;
        }

        return score;
        
    }


    void DecideWinPlayer()
    {
        if(player1Score > player2Score)
        {
            winPlayer = 1;
        }else if(player1Score < player2Score)
        {
            winPlayer = 2;
        }
    }

    public int GetWinPlayer()
    {
        return winPlayer;
    }




}
