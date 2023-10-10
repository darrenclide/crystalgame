using UnityEngine;

public class HelperScript : MonoBehaviour
{

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    public void HelloWorld(bool text)
    {
        if (text == true)
        {
            print("hello world");
        }
    }
}
