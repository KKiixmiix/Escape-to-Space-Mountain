/**
 *
 * player:
 * – InteractController  added to player to handle all orbs and player's movements around them.
 * Orbs:
 * – InteractableOrb    – inherits from Interactable and overrides the Interact() method.
 *                      – that class will call SwitchStateOnClick's methods.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class InteractionController : MonoBehaviour
{
    //public GameObject _target;
    //private GameObject _interactable;

    public GameObject _player;

    public GameObject _blueOrb;
    public GameObject _greenOrb;
    public GameObject _redOrb;
    public GameObject _blueFeOrb;
    public GameObject _greenFeOrb;
    public GameObject _redFeOrb;
    public GameObject _crystal;
    public GameObject _woodWand;
    public GameObject _natureWand;

    private Behaviour playHalo;
    private Behaviour blueOrbHalo;
    private Behaviour greenOrbHalo;
    private Behaviour redOrbHalo;
    private Behaviour blueFeOrbHalo;
    private Behaviour greenFeOrbHalo;
    private Behaviour redFeOrbHalo;
    private Behaviour crystalHalo;


    private void Start()
    {
        playHalo = (Behaviour) _player.GetComponent("Halo");
        playHalo.enabled = false;

        blueOrbHalo = (Behaviour) _blueOrb.GetComponent("Halo");
        blueOrbHalo.enabled = true;

        greenOrbHalo = (Behaviour) _greenOrb.GetComponent("Halo");
        greenOrbHalo.enabled = true;

        redOrbHalo = (Behaviour) _redOrb.GetComponent("Halo");
        redOrbHalo.enabled = true;

        blueFeOrbHalo = (Behaviour) _blueOrb.GetComponent("Halo");
        blueFeOrbHalo.enabled = true;

        greenFeOrbHalo = (Behaviour) _greenOrb.GetComponent("Halo");
        greenFeOrbHalo.enabled = true;

        redFeOrbHalo = (Behaviour) _redOrb.GetComponent("Halo");
        redFeOrbHalo.enabled = true;

        crystalHalo = (Behaviour) _crystal.GetComponent("Halo");
        crystalHalo.enabled = true;
    }

    private void Update()
    {

    }
}