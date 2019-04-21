using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUp;
    [SerializeField] int coinAdd = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().coinScore(coinAdd);
        AudioSource.PlayClipAtPoint(coinPickUp, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
