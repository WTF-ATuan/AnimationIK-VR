using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Actor.Scripts{
	public class Hand : MonoBehaviour{
		[SerializeField] private GameObject followObject;
		[SerializeField] private Vector3 positionOffset;
		[SerializeField] private float lerpSpeed = 2f;


		private TwoBoneIKConstraint ikConstraint;


		private void Start(){
			ikConstraint = GetComponent<TwoBoneIKConstraint>();
			var followPosition = followObject.transform.position;
			positionOffset = transform.position - followPosition;
			transform.position = followPosition;
		}

		private void Update(){
			var followPosition = followObject.transform.position + positionOffset;
			var position = transform.position;
			var distance = Vector3.Distance(followPosition, position);
			var lerpPosition = Vector3.Lerp(position, followPosition, lerpSpeed * distance * Time.deltaTime);
			transform.position = lerpPosition;
		}
	}
}