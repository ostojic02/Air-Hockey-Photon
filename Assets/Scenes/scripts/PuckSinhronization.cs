using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuckSync : MonoBehaviourPun, IPunObservable
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ako trenutni klijent nije vlasnik
        if (!photonView.IsMine)
        {
                photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       /* if (stream.IsWriting)
        {
            // Ako je trenutni klijent vlasnik, šalje podatke ostalima
            stream.SendNext(rb.position);
            stream.SendNext(rb.velocity);
        }
        else
        {
            // Ostali klijenti primaju podatke za interpolaciju
            latestPosition = (Vector2)stream.ReceiveNext();
            latestVelocity = (Vector2)stream.ReceiveNext();
        }*/
    }
}

