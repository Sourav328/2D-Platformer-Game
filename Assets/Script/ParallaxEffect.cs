using UnityEngine;
using System;



    [System.Serializable]
    public class BackgroundElement 
    {
        public SpriteRenderer backgroundSprite;
        [Range(0, 1)] public float ScrollSpeed;
        [HideInInspector] public Material spriteMaterial;
    }
public class ParallaxEffect : MonoBehaviour
{
    private const float Scroll_Multiplier = 0.01f;
    [SerializeField] private BackgroundElement[]backgroundElements;
    private void Start()
    {
        foreach(BackgroundElement element in backgroundElements)
        {
            element.spriteMaterial = element.backgroundSprite.material;

        }
    }
    private void Update()
    {
        foreach (BackgroundElement element in backgroundElements)
        {
            element.spriteMaterial.mainTextureOffset = new Vector2(transform.position.x * element.ScrollSpeed   * Scroll_Multiplier,0); 
        }
    }
}



