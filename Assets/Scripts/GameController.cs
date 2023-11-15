using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public int starterAmmo = 20;
   public int currentAmmo;
   public float speed = 1f;
   public GameObject player;
   public GameObject goodDoor;
   public GameObject badDoor;

   private void Start()
   {
      currentAmmo += starterAmmo;
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Fire();
         Debug.Log("You fired!!");
      }
   }

   public void PlayerMovement()
   {
      if (Input.GetKey(KeyCode.A))
      {
         //Sola Gider.
      }
      else if (Input.GetKey(KeyCode.D))
      {
         //Sağa Gider.
      }
   }
   
   public void Fire()
   {
      //TODO: Fire.
   }
}
