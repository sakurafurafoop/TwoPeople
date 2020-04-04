using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text player1Score;
    [SerializeField] Text player2Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1Score.text = ShootingGameManager.Instance.GetScore(1).ToString();
        player2Score.text = ShootingGameManager.Instance.GetScore(2).ToString();
    }
}
