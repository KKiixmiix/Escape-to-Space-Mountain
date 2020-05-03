using UnityEngine;
using UnityEditor;
using UnityEngine.VFX;

public class InteractableOrb : Interactable
{
    public override void Interact()
    {
        Debug.Log("Interacting with orb " + transform.name);
        changeHalo();
    }

    public void changeHalo()
    {
        SerializedObject orbHalo = new SerializedObject(GetComponent("Halo"));
        SerializedObject playHalo = new SerializedObject(player.GetComponent("Halo"));
        Color newColor = orbHalo.FindProperty("m_Color").colorValue;
        //halo.FindProperty("m_Size").floatValue = size;
        playHalo.FindProperty("m_Color").colorValue = newColor;
        playHalo.FindProperty("m_Enabled").boolValue = true;
        orbHalo.FindProperty("m_Enabled").boolValue = false;
        playHalo.ApplyModifiedProperties();
        orbHalo.ApplyModifiedProperties();
    }
}