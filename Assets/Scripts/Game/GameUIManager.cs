﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour {

	public static GameUIManager Instance { get; private set; }

    [HideInInspector]
    public DialogBox dialogBox;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            dialogBox = FindObjectOfType<DialogBox>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        dialogBox.gameObject.SetActive(false);
    }

    public void OpenDialogBox(string header, List<Dialog> dialogs)
    {
        dialogBox.gameObject.SetActive(true);
        dialogBox.Open(header, dialogs);
    }
}
