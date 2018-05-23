using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractionDialog : MonoBehaviour {

	public GameObject Brand;

    public string header;
    public List<Dialog> dialogs = new List<Dialog>();

    private bool dialogOpen;

	void Start(){
		Brand = GameObject.FindGameObjectWithTag ("Brand");
	}

    private void OnTriggerEnter(Collider other)
    {
		
        StartCoroutine(CheckIfDialog());
    }

    private void OnTriggerExit(Collider other)
    {
		
        StopAllCoroutines();
		Brand.SetActive (false);
    }

    IEnumerator CheckIfDialog()
    {
        while (true)
        {
			if (Brand.activeInHierarchy == false) {
				Brand.SetActive (true);
			}
			Brand.transform.Find("Text").GetComponent<Text>().text = "PRESS E TO INTERACT";

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!GameUIManager.Instance.dialogBox.gameObject.activeInHierarchy)
                {
					Cursor.visible = true;
                    //Inabilitar el movimiento del personaje
					FindObjectOfType<vThirdPersonInput>().enabled = false;
					Brand.transform.Find("Text").GetComponent<Text>().text = "";
					Brand.SetActive (false);
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
