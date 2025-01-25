using System;
using UnityEngine;

public class NomNomBoxController : MonoBehaviour
{
    [SerializeField] private FlyManager flyManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TongueTip") && flyManager.flyCount > 0)
        {
            Mouthanim.instance.ChangeState("Closed");
        }
    }
}
