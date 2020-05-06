using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.VFX;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Continue"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        changeHalo();
    }

    public void changeHalo()
    {
        SerializedObject orbHalo = new SerializedObject(GetComponent("Halo"));
        //SerializedObject playHalo = new SerializedObject(player.GetComponent("Halo"));
        //Color newColor = orbHalo.FindProperty("m_Color").colorValue;
        //halo.FindProperty("m_Size").floatValue = size;
        //playHalo.FindProperty("m_Color").colorValue = newColor;
        //playHalo.FindProperty("m_Enabled").boolValue = true;
        orbHalo.FindProperty("m_Enabled").boolValue = false;
        //playHalo.ApplyModifiedProperties();
        orbHalo.ApplyModifiedProperties();
    }
}
