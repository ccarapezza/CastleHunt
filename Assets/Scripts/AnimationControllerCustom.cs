using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class AnimationControllerCustom : MonoBehaviour
{

    public AnimationData[] animations;

    public AnimationData currentAnimation;

    public float timer;

    public int frame;

    public SpriteRenderer sp;
    public string initAnimation;
    public bool isPlaying;
    // Use this for initialization
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        ChangeAnimation(initAnimation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!(timer < 1 / currentAnimation.frameRate || !isPlaying)) {
            timer = 0;
            frame++;
            SetFrame();
        }
    }

    public void ChangeAnimation(string name)
    {
        if (name == currentAnimation.name) return;

        for (int i = 0; i < animations.Length; i++)
        {
            if (animations[i].name == name)
            {
                isPlaying = true;
                currentAnimation = animations[i];
                frame = 0;
                SetFrame();
            }
        }
    }

    public void SetFrame()
    {
        if (frame >= currentAnimation.sprites.Length)
        {
            if (currentAnimation.loop) frame = 0;
            else
            {
                isPlaying = false;
                frame--;
                if (currentAnimation.nextAnimation != null) ChangeAnimation(currentAnimation.nextAnimation);
            }

        }

        sp.sprite = currentAnimation.sprites[frame];
        TriggerEvents();
    }

    public void TriggerEvents() {
        AnimationEvent[] events = currentAnimation.events;
        for (int i = 0; i < events.Length; i++)
        {
            if (events[i].frame == frame) {
                SendMessage(events[i].function);
            }
        }
    }

    public void SetPlaying(bool value)
    {
        isPlaying = value;
    }

    [System.Serializable]
    public class AnimationData
    {
        public string name;
        public Sprite[] sprites;
        public AnimationEvent[] events;
        public bool loop;
        public float frameRate;
        public string nextAnimation = null;
    }

    [System.Serializable]
    public class AnimationEvent
    {
        public string name;
        public int frame;
        public string function;
    }
}
