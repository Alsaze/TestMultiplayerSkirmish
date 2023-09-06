using System;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCameraController : NetworkBehaviour
{
   [SerializeField] private GameObject playerCamera;

   public override void OnStartLocalPlayer()
   {
      CameraPosition();
      playerCamera = Instantiate(playerCamera, CameraPosition(), quaternion.identity);
   }

   public override void OnStopLocalPlayer()
   {
      Destroy(playerCamera);
   }

   private Vector3 CameraPosition()
   {
      float defaultCameraPositionZ = -8.65f;
      Vector3 cameraPosition = new Vector3(0, transform.position.y, defaultCameraPositionZ);
      return cameraPosition;
   }

   private void Update()
   {
      if (playerCamera != null)
      {
         CameraMovment();
      }
      else
      {
         Debug.Log("Camera == null");
      }
   }
   
   private void CameraMovment()
   {
      playerCamera.transform.position = CameraPosition();
   }
}
