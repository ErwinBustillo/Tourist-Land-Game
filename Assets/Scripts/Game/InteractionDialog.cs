using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractionDialog : MonoBehaviour {	

    public Quest requiredTask;
    public Quest currentTask;
    [Header("Before Quest Dialogs")]
    public List<Dialog> beforeRequiredQuestDialogs;
    public string header;
    [Header("Current Quest Dialogs")]
    public List<Dialog> dialogs = new List<Dialog>();

    private bool dialogOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

		GameUIManager.Instance.Brand.SetActive (true);
		GameUIManager.Instance.Brand.transform.Find("Text").GetComponent<Text>().text = "PRESS E TO INTERACT";

        StartCoroutine(CheckIfDialog());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;

        StopAllCoroutines();
		GameUIManager.Instance.Brand.SetActive (false);
    }

    IEnumerator CheckIfDialog()
    {
        while (true)
        {
            print(gameObject.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!GameUIManager.Instance.dialogBox.gameObject.activeInHierarchy)
                {
					Cursor.visible = true;
                    //Inabilitar el movimiento del personaje
					FindObjectOfType<vThirdPersonInput>().enabled = false;
					GameUIManager.Instance.Brand.transform.Find("Text").GetComponent<Text>().text = "";
					GameUIManager.Instance.Brand.SetActive (false);
                    //Debug.Log("Open Dialog");
                    if (QuestManager.Instance.CheckQuestState(requiredTask))
                    {
                        GameUIManager.Instance.OpenDialogBox(header, dialogs);
						if (currentTask != Quest.Null) {
							QuestManager.Instance.CompleteTask(currentTask);
						}
                        
                    }
                    else
                    {
                        GameUIManager.Instance.OpenDialogBox(header, beforeRequiredQuestDialogs);
                    }
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

    public Dialog() { }

    public Dialog(string message)
    {
        this.message = message;
        isQuestion = false;
    }
}

[System.Serializable]
public class Answer
{
    public string answerMessage;
    public Dialog responseDialog;
    public UnityEvent OnResponse = new UnityEvent();
}
