using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Balloon1")
        {
            ShootingGameManager.Instance.ChangeScore(1);
            Destroy(collision.gameObject);
            BalloonGenerator.Instance.GenerateBalloon(collision.gameObject.transform.position.y);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Balloon2")
        {
            ShootingGameManager.Instance.ChangeScore(2);
            Destroy(collision.gameObject);
            BalloonGenerator.Instance.GenerateBalloon(collision.gameObject.transform.position.y);
            
            Destroy(this.gameObject);
        }

       
    }

   
}
