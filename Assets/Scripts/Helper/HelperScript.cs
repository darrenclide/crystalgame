using UnityEngine;

public class HelperScript : MonoBehaviour
{

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
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
