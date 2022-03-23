using System;
using UnityEngine;

namespace Actor.Scripts{
	public class PhysicsHand : MonoBehaviour{
		[SerializeField] private GameObject followObject;
		[SerializeField] private Vector3 positionOffset;
		[SerializeField] private float followSpeed = 10f;
		
		private new Rigidbody rigidbody;
		
		private void Start(){
			var followPosition = followObject.transform.position;
			positionOffset = transform.position - followPosition;
			transform.position = followPosition;
			rigidbody = GetComponent<Rigidbody>();
			rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
			rigidbody.mass = 20f;
		}

		private void Update(){
			var followPosition = followObject.transform.position + positionOffset;
			var distance = Vector3.Distance(followPosition , transform.position);
			rigidbody.velocity = (followPosition - transform.position).normalized * (followSpeed * distance);
		}
	}
}