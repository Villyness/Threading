using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threading : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public int width;
    public int height;
    public Renderer OwnRenderer;
    public Texture2D tex;
    public float perlinNoise;
    public float scale = 0.01f;
    //public Color

    // Start is called before the first frame update
    void Start()
    {
        tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        OwnRenderer = GetComponent<Renderer>();
        OwnRenderer.material.mainTexture = tex;
        Color testColour;   // new Color(1, 0, 1, 1);

        for (x = 0; x < width; x++)
        {
            for (y = 0; y < height; y++)
            { 
                perlinNoise = Mathf.PerlinNoise(x * scale, y * scale);
                testColour = new Color(perlinNoise, perlinNoise, perlinNoise);
                tex.SetPixel((int)x, (int)y, testColour);
            }
        }
        //perlinNoise = Mathf.PerlinNoise(x * scale, y * scale);
        tex.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
