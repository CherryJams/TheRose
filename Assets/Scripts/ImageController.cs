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
        currentImage = gameObject.GetComponent<UnityEngine.UI.Image>();
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
}