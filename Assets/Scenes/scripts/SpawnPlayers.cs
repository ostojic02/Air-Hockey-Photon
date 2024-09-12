using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject puckPrefab;

    public PhysicsMaterial2D bouncyMaterial;
    public float bouncinessValue = 1f;
    private CircleCollider2D circleCollider;

    public float X;
    public float Y;
    /*public float PX;
    public float PY;*/

    private void Start()
    {

        circleCollider = GetComponent<CircleCollider2D>();

        Vector2 position = new Vector2 (X, Y);
        Vector2 position1 = new Vector2(0, 0);

        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(puckPrefab.name, position1, Quaternion.identity);            
        }
        
    }
}
