using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Threading : MonoBehaviour
{
    public int x = 0;
    public int y = 0;
    public int width;
    public int height;
    public Renderer OwnRenderer;
    public Texture2D tex;
    public float perlinNoise;
    public float scale = 0.01f;
    public Color[] testColour;
    public Thread newThread;
    //public Color
    public int xcoord;
    public int ycoord;

    // Start is called before the first frame update
    void Start()
    {
        tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
        OwnRenderer = GetComponent<Renderer>();
        OwnRenderer.material.mainTexture = tex;

        testColour = new Color[width * height];
        // new Color(1, 0, 1, 1);
        /*if(newThread.IsAlive)
        {
            tex.SetPixel((int)x, (int)y, testColour);
        }*/
        newThread = new Thread(ThreadFunction);
        newThread.Start();
    }

    public void Update()
    {
        if(!newThread.IsAlive)
        {
            Debug.Log("Main thread: New thread finished");
            tex.SetPixels(testColour);

            tex.Apply();


            newThread = new Thread(ThreadFunction);
            newThread.Start();
        }
    }

    public void ThreadFunction()
    {
        for (x = 0; x < width; x++)
        {
            for (y = 0; y < height; y++)
            {
                perlinNoise = Mathf.PerlinNoise(x * scale, y * scale);
                testColour[x + y * width] = new Color(perlinNoise, perlinNoise, perlinNoise);
            }
        }
    }


}
