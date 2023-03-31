using UnityEngine;

public class SpriteContainer : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
     
    public Sprite[] GetSprites()
    {
        return sprites;
    }
}