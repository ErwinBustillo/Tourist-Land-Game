using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpDetector : MonoBehaviour {



	// si entra el player en contacto con el objeto
	void OnTriggerEnter(Collider other){
		//Muestre un texto diciendole al jugador que lo puede recoger dependiendo del tipo de objeto
		Debug.Log("ENTRO " +other.gameObject.name);
	}


	void OnTriggerExit(Collider other){
		Debug.Log("SALIO" + other.gameObject.name);
	}

	IEnumerator WaitForPickUp()
	{
		while (true)
		{
			

			/*
			//Targeter plyTargeter = playerInvHandler.GetComponent<Targeter>();

			if(plyTargeter.Target == this.transform.parent){
				pickupCanvas.SetActive(true);// activa el tooltip
				pickupCanvas.transform.LookAt(Camera.main.transform); // mira al player
			}
			else
			{
				pickupCanvas.SetActive(false);// desactiva el tooltip
			}

			if (Input.GetKeyDown(KeyCode.E) && plyTargeter.Target == this.transform.parent)
			{
				pickupCanvas.SetActive(false);// desactiva el tooltip
				GetComponentInParent<Item>().PickUp(playerInvHandler);

			}*/

			yield return null;
		}
	}

}
