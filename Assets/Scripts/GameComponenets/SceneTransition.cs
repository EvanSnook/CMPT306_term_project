using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
	public Texture2D FadeOutTexture; // This is the texture that will black out the screen.
	public float FadeOutSpeed; // This is how fast the fade out takes.

	private int DrawDepth = -1000; // This is the texture's order in the draw hierarchy. The lower the number renders on top.
	private float Alpha = 1.0f; // This is the alpha value of the testure. It goes between 0 and 1.
	private int FadeDirection = -1; // This is the direction to fade: FadeIn = -1 and FadeOut = 1.

	void OnGUI () {
		// Fade in or out the alpha useing a direction, speed, and Time to convert the operation to seconds.
		Alpha += FadeDirection * FadeOutSpeed * Time.deltaTime;

		// This forces the number between 0 and 1 becuase GUI.color uses alpha values between 0 and 1.
		Alpha = Mathf.Clamp01 (Alpha);

		// Set the color of our GUI. All color stay the same and the Alpha is set to the Alpha.
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, Alpha); // This sets the alpha.
		GUI.depth = DrawDepth; // This is to make sure that the texture is rendered on top.
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),FadeOutTexture); // This draws the texture to fit the screen.
	}

	public float BeginFade(int Direction) {
		FadeDirection = Direction;
		return(FadeOutSpeed);
	}

	void OnLevelWasLoaded() {
		BeginFade (-1); // Call the Fade In function.	
	}

	// This will change to anotherLevel.
	IEnumerator ChangeLevel() {
		float FadeTime = BeginFade (1);
		yield return new WaitForSeconds (FadeTime);
		SendMessage ("ChangeScene");
	}


}
