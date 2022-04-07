using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawner;

    public void Spawn()
    {
        player.transform.position = new Vector3(spawner.position.x, spawner.position.y, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Kayboardinput>())
        {
            Spawn();
        }

    }

}
