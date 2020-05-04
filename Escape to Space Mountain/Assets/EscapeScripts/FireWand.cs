using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldTreeStudio.Example
{ 
    public class FireWand : MonoBehaviour
    { 
        public GameObject _wand;
        public GameObject _orb;
        public GameObject _player;
        private bool on = false;
        private bool up = false;
        public readonly float limit = 3f;

        private IMRock _mRock;          //It's better to use rock simplified interface


        private void Start()
        {
            //Need controller script to grab object to initiate process
        }

        private void Update()
        {
            Vector3 player = _player.transform.position;
            Vector3 picked = _wand.transform.position;
            //Debug.Log("Player:" + player + ", wand r: " + picked + "; distance: " + Vector3.Distance(player, picked));
            if (!up && limit > Vector3.Distance(player, picked))
            {
                Debug.Log("Player position (up): " + player + ", " + picked);
                up = true;
            }
            if (up && !on)
            {
                Vector3 rock = _orb.transform.position;
                //Debug.Log("Player position (up && !on): " + player + ". Rock: " + rock + ". Distance: " + Vector3.Distance(player, rock));
                if (limit > Vector3.Distance(player, _orb.transform.position))
                {
                    Debug.Log("Player position (up && !on): " + player + ". Rock: " + rock + ". Distance: " + Vector3.Distance(player, rock));
                    //Debug.Log("Player position (limit > MR.pos): " + player);
                    _mRock.SwitchState();
                    on = true;
                }
            }
        }
    }
}
