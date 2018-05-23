using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

    public Text headerText;
    public Text messageText;
    public Button nextButton;
    public RectTransform answersRegion;
    public RectTransform answersContent;
    public Button answerButtonPrefab;

    [HideInInspector]
    public string header;
    [HideInInspector]
    public List<Dialog> dialogs;

    private string Header
    {         
        set
        {
            headerText.text = value;
        }
    }

    private string DialogMessage
    {
        set
        {
            messageText.text = value;
        }
    }

    private int currentDialog = 0;

    private void Start()
    {
        //print("hola sart");
        nextButton.onClick.AddListener(delegate { OnNextButtonClick(); });
        currentDialog = 0;
    }

    public void Open(string header, List<Dialog> dialogs)
    {
        Cursor.visible = true;
        this.dialogs = dialogs;
        this.header = header;

        ShowDialog(dialogs[currentDialog]);
    }

    private void ShowDialog(Dialog dialog)
    {
        Header = header;
        DialogMessage = dialog.message;
        answersRegion.gameObject.SetActive(dialog.isQuestion);
        nextButton.gameObject.SetActive(!dialog.isQuestion);

        if (dialog.isQuestion)
        {
            if (answersContent.childCount > 0)
            {
                //Desstroy the previous answer buttons
                for (int index = 0; index < answersContent.childCount; index++)
                {
                    Destroy(answersContent.GetChild(index).gameObject);
                }
            }

            foreach (var answer in dialog.answers)
            {

                Button button = Instantiate(answerButtonPrefab);
                button.transform.SetParent(answersContent);
                button.GetComponentInChildren<Text>().text = answer.answerMessage;
                button.onClick.AddListener(() =>
                {
                    if (answer.OnResponse != null)
                        answer.OnResponse.Invoke();

                    ShowDialog(answer.responseDialog);
                });
            }
        }
    }

    private void OnNextButtonClick()
    {
        currentDialog++;
        if(currentDialog < dialogs.Count)
        {
            ShowDialog(dialogs[currentDialog]);
        }
        else
        {
			Cursor.visible = false;
			FindObjectOfType<vThirdPersonInput>().enabled = true;
            Close();
        }
    }

    public void Close()
    {
       
        header = string.Empty;
        Header = string.Empty;
        DialogMessage = string.Empty;
        dialogs = null;
        currentDialog = 0;
        for (int index = 0; index < answersContent.childCount; index++)
        {
            Destroy(answersContent.GetChild(index).gameObject);
        }
        gameObject.SetActive(false);
    }
}
