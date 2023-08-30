using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
   [SerializeField] private Camera playerCamera;
   private Vector3 _defaultCameraPosition;

   public override void OnStartAuthority()
   {
      _defaultCameraPosition = new Vector3(0, 0, -1);
      playerCamera = playerCamera.GetComponent<Camera>();
   }
   private void Update()
   {
      // if (!isLocalPlayer)
      // {
      //    return;
      // }
      CameraMovment();
   }

   private void CameraMovment()
   {
      _defaultCameraPosition = new Vector3(0, transform.position.y, -10);
      playerCamera.transform.position = _defaultCameraPosition;
   }
}
