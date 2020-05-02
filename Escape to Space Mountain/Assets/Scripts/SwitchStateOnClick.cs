using UnityEngine;


namespace OldTreeStudio.Example
{
    public class SwitchStateOnClick : MonoBehaviour
    {
        public GameObject _crystal;
        public GameObject _woodWand;
        public GameObject _natureWand;
        public GameObject _target;
        public GameObject _player;
        private Behaviour playHalo;
        private Behaviour greenOrbHalo;
        private Behaviour redOrbHalo;
        private Behaviour purpleOrbHalo;
        private bool on = false;
        private bool up = false;
        public readonly float limit = 3f;

        private IMRock _mRock;          //It's better to use rock simplified interface


        private void Start()
        {
            //Accessing the interface of MRock
            _mRock = _target.GetComponent<IMRock>();
            _mRock.SwitchState();
            greenOrbHalo = (Behaviour)_crystal.GetComponent("Halo");
            greenOrbHalo.enabled = true;
            playHalo = (Behaviour)_player.GetComponent("Halo");
            playHalo.enabled = false;
        }

        private void Update()
        {
            Vector3 player = _player.transform.position;
            Vector3 picked = _crystal.transform.position;
            //Debug.Log("Player:" + player + ", PUOb r: " + picked + "; distance: " + Vector3.Distance(player, picked));
            if (!up && limit > Vector3.Distance(player, picked)) {
                Debug.Log("Player position (up): " + player + ", " + picked);
                up = true;
                greenOrbHalo.enabled = false;
                playHalo.enabled = true;
            }
            if (up && !on) {
                Vector3 rock = _target.transform.position;
                //Debug.Log("Player position (up && !on): " + player + ". Rock: " + rock + ". Distance: " + Vector3.Distance(player, rock));
                if (limit > Vector3.Distance(player, _target.transform.position)) {
                    Debug.Log("Player position (up && !on): " + player + ". Rock: " + rock + ". Distance: " + Vector3.Distance(player, rock));
                    //Debug.Log("Player position (limit > MR.pos): " + player);
                    _mRock.SwitchState();
                    on = true;
                    playHalo.enabled = false;
                }
            }
        }
    }
}