using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Actor.Scripts{
	public class IKHand : MonoBehaviour{
		[SerializeField] private GameObject followObject;
		[SerializeField] private Vector3 positionOffset;

		private TwoBoneIKConstraint boneIKConstraint;

		private void Start(){
			boneIKConstraint = GetComponentInParent<TwoBoneIKConstraint>();
			var followPosition = followObject.transform.position;
			positionOffset = transform.position - followPosition;
			transform.position = followPosition;
		}

		private void Update(){
			var followPosition = followObject.transform.position + positionOffset;
			var position = transform.position;
			var distance = Vector3.Distance(followPosition, position);
			var lerpPosition = Vector3.Lerp(position, followPosition, 20f * distance * Time.deltaTime);
			transform.position = lerpPosition;
			boneIKConstraint.data.tip.transform.position = followPosition;
		}
	}
}