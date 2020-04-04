using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BalloonGenerator : SingletonMonoBehaviour<BalloonGenerator>
{
    [SerializeField] GameObject balloon1, balloon2;
    GameObject[] balloons = new GameObject[8];
    int balloonsLength = 0;
    int ballonNumber = 8;
    bool stateOn;
    
    // Start is called before the first frame update
    void Start()
    {
        BalloonsReset();
        stateOn = false;

        for(int i = -4; i < 4; i++)
        {
            GenerateBalloon(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BalloonsReset()
    {
        
        for (int i = 0; i < ballonNumber; i++)
        {
            if(i < 4)
            {
                balloons[i] = balloon1;
            }else if(i >= 4 && i < ballonNumber)
            {
                balloons[i] = balloon2;
            }
            
        }


        balloons = balloons.OrderBy(i => Guid.NewGuid()).ToArray();
    }



    public void GenerateBalloon(float yPos)
    {
        switch (stateOn)
        {
            case true:
                StartCoroutine("InstantiateBalloon", yPos);
                break;

            case false:
                Instantiate(balloons[balloonsLength], new Vector3(0, yPos, -2.8f), Quaternion.identity);
                break;
        }
        
        balloonsLength++;
        if(balloonsLength >= ballonNumber)
        {
            balloonsLength = 0;
            BalloonsReset();
            stateOn = true;
        }
    }

    IEnumerator InstantiateBalloon(float yInstaPos)
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(balloons[balloonsLength], new Vector3(0, yInstaPos, -2.8f), Quaternion.identity);
        yield break;

    }

    
}
