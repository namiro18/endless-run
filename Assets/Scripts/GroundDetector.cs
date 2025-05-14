using UnityEngine;
using System.Collections;
public class GroundDetector : MonoBehaviour
{
 public Transform RayDestination;
 public bool IsGrounded;
 private int _groundmask;
 void Awake()
 {
 _groundmask = LayerMask.GetMask("Ground");
 }
 void Update()
 {
 if (Physics2D.Linecast(this.transform.position,
RayDestination.position, _groundmask))
 IsGrounded = true;
 else
 IsGrounded = false;
 }
}