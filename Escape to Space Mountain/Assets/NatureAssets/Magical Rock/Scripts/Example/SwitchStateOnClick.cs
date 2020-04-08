using UnityEngine;


namespace OldTreeStudio.Example
{
	public class SwitchStateOnClick : MonoBehaviour
	{
		public GameObject _magicalRockGO;
		public GameObject _player;
		private bool on = false;
		private readonly float limit = 3f;

		private IMRock _mRock;			//It's better to use rock simplified interface


		private void Start ()
		{
			//Accessing the interface of MRock
			_mRock = _magicalRockGO.GetComponent<IMRock> ();
			_mRock.SwitchState();
		}

		private void Update ()
		{
			//Simple switch state on a screen click event
			float distance = Vector3.Distance(_magicalRockGO.transform.position, _player.transform.position);
			if (distance < limit && !on)
            {
				_mRock.SwitchState();
				on = true;
			}
				

		}
	}
}