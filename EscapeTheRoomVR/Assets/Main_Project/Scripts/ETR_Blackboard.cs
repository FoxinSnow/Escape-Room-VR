using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Fei Huang(Algorithm), Yuqi Wang(VR Interaction)
public class ETR_Blackboard : MonoBehaviour {

    private bool isEraserCollided;
    public Transform blackBoardEraser, eraserDirection;

    private Texture2D texture;

    public Texture2D cover;

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

            Ray ray = new Ray(blackBoardEraser.position, eraserDirection.position);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "BoardCover")
                {
                    Debug.Log(hitInfo.textureCoord * w);

                    int x = (int)(hitInfo.textureCoord.x * w);
                    int y = (int)(hitInfo.textureCoord.y * h);
  
                    Color[] c = texture.GetPixels(x - 4, y - 4, 96, 96);
                    for (int i = 0; i < c.Length; i++)
                    {
                        c[i].a = 0.0f;
                    }
                    texture.SetPixels(x - 4, y - 4, 96, 96, c);
                    texture.Apply();
                    GetComponent<Renderer>().material.mainTexture = texture;
                }
            }
        }
    }

    public void IsEraserCollided(bool isCollided)
    {
        isEraserCollided = isCollided;
    }

}
