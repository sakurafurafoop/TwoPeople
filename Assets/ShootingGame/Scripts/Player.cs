using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShootingGameManager.Instance.GetNowState() == ShootingGameManager.gameState.gamePlaying)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 1, 0);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, -1, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(ball, this.gameObject.transform.position, Quaternion.identity);
            }
        }
        
    }
}
