using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] Player player;

    [Range(5, 25)]
    [SerializeField] int healAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealPlayer();
    }

    private void HealPlayer()
    {
        Destroy(gameObject);
        player.AddHealth(healAmount);
    }
}
