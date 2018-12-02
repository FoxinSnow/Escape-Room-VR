using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Fei Huang(Algorithm), Yuqi Wang(VR Interaction)
public class ETR_Blackboard : MonoBehaviour {

    public Transform blackboardEraser, eraserDirection;
    public Texture2D cover;
    private bool isEraserCollided;
    private Texture2D texture;
    private int w, h;

    // Use this for initialization
    void Start()
    {
        // Initialisation
        isEraserCollided = false;
        w = cover.width;
        h = cover.height;
        texture = new Texture2D(w, h);

        // Copy the image to texture
        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                texture.SetPixel(x, y, cover.GetPixel(x, y));
            }
        }
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {

        if (isEraserCollided)
        {

            Ray ray = new Ray(blackboardEraser.position, eraserDirection.position);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "BoardCover")
                {
                    Debug.Log(hitInfo.textureCoord * w);

                    int x = (int)(hitInfo.textureCoord.x * w);
                    int y = (int)(hitInfo.textureCoord.y * h);

                    int range = 96; //a square 96 * 96

                    //boarder check
                    if (x < range/2 + 1 || x > 2048 - range/2 - 1
                        || y < range/2 + 1 || y > 2048 - range/2 - 1) 
                        //on the boarder, remove one by one
                    {
                        Color c = texture.GetPixel(x, y);
                        c.a = 0.0f;
                        texture.SetPixel(x, y, c);
                        texture.Apply();
                        GetComponent<Renderer>().material.mainTexture = texture;
                    }
                    else //in the middle, remove in a range
                    {
                        Color[] c = texture.GetPixels(x - range / 2, y - range / 2, range, range);
                        for (int i = 0; i < c.Length; i++)
                        {
                            c[i].a = 0.0f;
                        }
                        texture.SetPixels(x - range / 2, y - range / 2, range, range, c);
                        texture.Apply();
                        GetComponent<Renderer>().material.mainTexture = texture;
                    }
                }
            }
        }


    }

    public void IsEraserCollided(bool isCollided)
    {
        isEraserCollided = isCollided;
    }

}
