using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ImageController : MonoBehaviour
{
    private SpriteContainer spriteContainer;

    private Image currentImage;
    // Start is called before the first frame update

    private void Start()
    {
        currentImage = gameObject.GetComponent<Image>();
        spriteContainer = FindObjectOfType<SpriteContainer>();
    }

    [YarnCommand("setSprite")]
    public void SetCurrentSprite(string spriteName)
    {
        Sprite[] sprites = spriteContainer.GetSprites();
        foreach (var sprite in sprites)
        {
            if (sprite.name == spriteName)
            {
                currentImage.sprite = sprite;
                break;
            }
        }
    }

    [YarnCommand("setAlpha")]
    public void SetAlpha(float alpha)
    {
        Color color = currentImage.color;
        color.a = alpha;
        currentImage.color = color;
    }

    [YarnCommand("fade")]
    public void Fade(bool turnOpaque = true, int fadeSpeed = 5)
    {
        StartCoroutine(FadeCoroutine(turnOpaque, fadeSpeed));
    }
    public IEnumerator FadeCoroutine(bool turnOpaque = true, int fadeSpeed = 5)
    {
        Color imageColor = currentImage.color;
        float fadeAmount;
        if (turnOpaque)
        {
            while(imageColor.a < 1)
            {
                fadeAmount = imageColor.a + (fadeSpeed * Time.deltaTime);
                imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
                currentImage.color = imageColor;
                yield return null;
            }
        }
        else
        {
            while (currentImage.color.a > 0)
            {
                fadeAmount = imageColor.a - (fadeSpeed * Time.deltaTime);
                imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
                currentImage.color = imageColor;
                yield return null;
            }
        }
    }
}