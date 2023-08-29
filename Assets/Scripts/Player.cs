using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
   [SerializeField] private Joystick joystick;
   private Rigidbody2D _rb;
   [SerializeField] private Camera playerCamera;

   private Vector2 _moveInput;

   private void Start()
   {
      _rb = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      // if (!isLocalPlayer)
      // {
      //    return;
      // }
      CameraMovment();
   }

   private void FixedUpdate()
   {
      PlayerMovment();
   }
   private void PlayerMovment()
   {
      float moveSpeed = 1.5f;
      Vector3 moveDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
      
      _rb.velocity = moveDirection * moveSpeed;
      
      if (moveDirection!=Vector3.zero)
      {
         PlayerDirection(moveDirection);
      }
   }

   private void PlayerDirection(Vector3 moveDirection)
   {
      transform.rotation = Quaternion.LookRotation(Vector3.forward,
         moveDirection);
   }

   private void CameraMovment()
   {
      Vector3 defaultCameraPosition = new Vector3(0, transform.position.y, -10);
      playerCamera.transform.position = defaultCameraPosition;
   }
}
