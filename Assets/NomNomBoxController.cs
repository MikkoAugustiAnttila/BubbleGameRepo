using System;
using UnityEngine;

public class NomNomBoxController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TongueTip"))
        {
            Mouthanim.instance.ChangeState("Closed");
        }
    }
}
