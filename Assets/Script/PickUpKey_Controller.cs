using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey_Controller : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller playercontroller = collision.gameObject.GetComponent<Player_Controller>();
            playercontroller.PickUpKey();
            Destroy(gameObject);
        }
    }   

}
