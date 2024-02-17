using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public float coin = 0;


    public TextMeshProUGUI textCoins;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
            player.transform.position = respawnPoint.transform.position;
        coin = 0;
        textCoins.text = coin.ToString();

    }
}
