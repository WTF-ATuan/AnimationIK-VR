using UnityEngine;

namespace Actor.Scripts{
	[RequireComponent(typeof(Rigidbody))]
	public class PhysicsHand : MonoBehaviour{
		[SerializeField] private GameObject followObject;
		[SerializeField] private Vector3 positionOffset;
		[SerializeField] private float followSpeed = 30f;


		private new Rigidbody rigidbody;

		private void Start(){
			rigidbody = GetComponent<Rigidbody>();
			var followPosition = followObject.transform.position;
			positionOffset = transform.position - followPosition;
			transform.position = followPosition;
		}

		private void Update(){
			var followPosition = followObject.transform.position + positionOffset;
			var position = transform.position;
			var distance = Vector3.Distance(followPosition, position);
			rigidbody.velocity = (positionOffset - position).normalized * (followSpeed * distance);
		}
	}
}