using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameManager : SingletonMonoBehaviour<ShootingGameManager>
{
    int player1Score,player2Score;

    
    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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



    

    
}
