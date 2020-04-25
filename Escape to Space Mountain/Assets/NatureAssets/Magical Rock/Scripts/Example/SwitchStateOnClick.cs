﻿using UnityEngine;


namespace OldTreeStudio.Example
{
    public class SwitchStateOnClick : MonoBehaviour
    {
        public GameObject _crystalKey;
        public GameObject _heartStone;
        public GameObject _player;
        public Behaviour playHalo;
        public Behaviour pugoHalo;
        private bool on = false;
        private bool up = false;
        public readonly float limit = 3f;

        private IMRock _mRock;          //It's better to use rock simplified interface


        private void Start()
        {
            //Accessing the interface of MRock
            _mRock = _heartStone.GetComponent<IMRock>();
            _mRock.SwitchState();
            pugoHalo = (Behaviour)_crystalKey.GetComponent("Halo");
            pugoHalo.enabled = true;
            playHalo = (Behaviour)_player.GetComponent("Halo");
            playHalo.enabled = false;
        }

        private void Update()
        {
            Vector3 player = _player.transform.position;
            Vector3 picked = _crystalKey.transform.position;
            //Debug.Log("Player:" + player + ", PUOb r: " + picked + "; distance: " + Vector3.Distance(player, picked));
            if (!up && limit > Vector3.Distance(player, picked)) {
                Debug.Log("Player position (up): " + player + ", " + picked);
                up = true;
                pugoHalo.enabled = false;
                playHalo.enabled = true;
            }
            if (up && !on) {
                Vector3 rock = _heartStone.transform.position;
                //Debug.Log("Player position (up && !on): " + player + ". Rock: " + rock + ". Distance: " + Vector3.Distance(player, rock));
                if (limit > Vector3.Distance(player, _heartStone.transform.position)) {
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