using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller player = collision.GetComponent<Player_Controller>();

        if (player != null)
        {
            //player.EnableDoubleJump();
            Destroy(gameObject); 
            Debug.Log("Double Jump Enabled!");
        }
    }

}
