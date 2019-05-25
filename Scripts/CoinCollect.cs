using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUp;
    [SerializeField] int coinAdd = 1;
    public GameObject[] respawns;
    public bugfix c;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        c = FindObjectOfType<bugfix>();
        if (!c.changed)
        {
            GameObject.FindGameObjectsWithTag("JumpTrigger");
            {
                FindObjectOfType<GameSession>().coinScore(coinAdd);
                AudioSource.PlayClipAtPoint(coinPickUp, Camera.main.transform.position);

                Destroy(gameObject);
                
                c.changed = true;
            }
        }

    }
}
