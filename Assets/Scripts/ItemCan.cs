using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float rotatSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * rotatSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            PlayerBall player = other.GetComponent<PlayerBall>();
            player.itemCount++;
            gameObject.SetActive(false);
        }
    }
}
