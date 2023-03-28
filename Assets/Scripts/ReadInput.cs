using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ReadInput : MonoBehaviour
{
    private string tempInput = "";
    private DialogueRunner dialogueRunner;
    private InMemoryVariableStorage variableStorage;

    private void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();
    }

    public void ReadStringInput(string input)
    {
        this.tempInput = input;
        Debug.Log(this.tempInput);
    }

    public void ReadPlayerName(string name)
    {
        ReadStringInput(name);
        dialogueRunner.StartDialogue("Start");
        variableStorage.SetValue("$player_name", name);
    }
}