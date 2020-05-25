using UnityEngine;
using System.Collections;
 
public class AnimationScript : MonoBehaviour
{
    public Sprite[] frames;
    public bool loop = false;
    public float speed = 0.13f;
    private SpriteRenderer rend;
    private int currentFrame;
    public bool playing = false;
 
    public void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        Play();
    }
 
    public void Play()
    {
        StartCoroutine(PlayAnim());
    }
 
    private IEnumerator PlayAnim()
    {
        playing = true;
        currentFrame = 0;
        rend.sprite = frames[currentFrame];
        currentFrame++;
 
        while (currentFrame < frames.Length)
        {
            yield return new WaitForSeconds(speed);
            rend.sprite = frames[currentFrame++];
            Debug.Log("frame: " + currentFrame);
        }
 
        if (loop)
            Play();
        else
            playing = false;
    }
}
 