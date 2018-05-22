using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class PhotoManager : MonoBehaviour {

	public Image imagenPhoto;

	// Use this for initialization
	void Start () {
		imagenPhoto.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) { // toma la foto 
			//StartCoroutine (TakeScreenshot ());
		}
		if (Input.GetKeyDown(KeyCode.O)) { // la deja de renderizar
			//StopCoroutine ("TakeScreenshot");
		}
	}

	//NO SIRVE
	/*
	public IEnumerator TakeScreenshot()
	{

		string imageName = "screenshot.png";

		// Take the screenshot
		ScreenCapture.CaptureScreenshot(imageName);

		//Wait for 4 frames
		for (int i = 0; i < 5; i++)
		{
			yield return null;
		}

		// Read the data from the file
		byte[] data = File.ReadAllBytes(Application.persistentDataPath + "/" + imageName);

		// Create the texture
		Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height);

		// Load the image
		screenshotTexture.LoadImage(data);

		// Create a sprite
		Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));

		// Set the sprite to the screenshotPreview 
		//TODO mostrar en algun lado el screenshot que se tomo
		imagenPhoto.gameObject.SetActive(true);
		imagenPhoto.sprite = screenshotSprite;
		//screenshotPreview.GetComponent<Image>().sprite = screenshotSprite;

	}*/

}
