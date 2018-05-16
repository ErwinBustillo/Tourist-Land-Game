using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionDialog : MonoBehaviour {

    public string header;
    public List<Dialog> dialogs = new List<Dialog>();

    private bool dialogOpen;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CheckIfDialog());
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    IEnumerator CheckIfDialog()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!GameUIManager.Instance.dialogBox.gameObject.activeInHierarchy)
                {
                    //Inabilitar el movimiento del personaje
                    Debug.Log("Open Dialog");
                    GameUIManager.Instance.OpenDialogBox(header, dialogs);
                }
            }
            yield return 1;
        }
    }

}

[System.Serializable]
public class Dialog
{
    public string message;
    public bool isQuestion;
    public Answer[] answers;
}

[System.Serializable]
public class Answer
{
    public string answerMessage;
    public Dialog responseDialog;
    public UnityEvent OnResponse = new UnityEvent();
}
