using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 

public class PuckScript : MonoBehaviour   
    {
    public ScoreScript scs;
    public static bool goal{ get; private set; }
    private Rigidbody2D rb;
    public Transform Player1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goal = false;
    }

    void Update()
    {
        if (!PhotonNetwork.IsMasterClient){
            return;
        }
    }

   /* private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!goal) 
        {
            if (collider.tag == "P2Goal")
            {
                scs.IncrementScore(ScoreScript.Score.Player1);
                goal = true;
                StartCoroutine(ResetPuck());
            }
            *//*else if(collider.tag == "P1Goal")
            {
                scs.IncrementScore(ScoreScript.Score.Player2);
                goal = true;
                StartCoroutine(ResetPuck());
            }*//*
        }
    }*/

    public IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        goal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
        Player1.position = new Vector2(-0.007f, -1f);
        /*Player2.position = new Vector2(-0.007f, 1f); */
    }

    public void ResetPuckInGame()
    {
        goal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
        Player1.position = new Vector2(-0.007f, -1f);
       /* Player2.position = new Vector2(-0.007f, 1f);*/
    }
}
