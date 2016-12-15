using UnityEngine;
using System.Collections;

public class PlayerFlashOnDamage : MonoBehaviour {

    public float FlashDuration; // This is the length of time that the sprite with this script changes colour.

    private SpriteRenderer Sprite; // This is the sprite renderer which is where the colour can be edited.
    private Color original;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>(); // This gets the sprite renderer component of this object.
        original = Sprite.color;
    }

    // This is called when damage is done to this object. It will change the colour of this object.
    public void ApplyDMG(int DMG)
    {
        Sprite.color = Color.white;
        StartCoroutine("RevertColor"); // This starts the Coroutine that will change the colour back to its original colour.
    }

    // This will revert the colour to the red after the Flash Duration has passed.
    IEnumerator RevertColor()
    {
        yield return new WaitForSeconds(FlashDuration);
        Sprite.color = original;
    }


}
