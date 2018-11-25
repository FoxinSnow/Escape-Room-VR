using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Fei Huang
public class CoverOperation : MonoBehaviour {



    /*please read
     * 1. The chalk function has not added now
     * 2. The cover texture will display in the game as a input of this script
     * 3. The cover will be initialized at the start of the game
     * 4. Do not change the transform relationship
     */

    private Texture2D texture;//text to store cover image
                              //avoid editing input image
    public Texture2D cover;//input image (the cover png)
    private int w, h; //width and height of the cover

    // Use this for initialization
    void Start () {
        //initialisation
        w = cover.width;
        h = cover.height;
        texture = new Texture2D(w, h);

        //copy the image to texture
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
	void Update () {
        
        //tracing the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawLine(ray.origin, ray.direction, Color.red, 2);
        RaycastHit hitInfo;

        //this part is the ray tracing of mouse, need to be changed in VR
        //in VR there should still use ray tracing from the eraser center
        //and to the collider of the cover board

        //if there is collider
        if (Physics.Raycast(ray, out hitInfo))
        {
            //if collider is right
            if (hitInfo.collider.tag == "BoardCover")
            {
                Debug.Log(hitInfo.textureCoord * w);

                //core code
                int x = (int)(hitInfo.textureCoord.x * w);
                int y = (int)(hitInfo.textureCoord.y * h);
                //change the pixel in a region
                //the region can be adjusted
                //remember the get and set pixels number should be same!
                Color[] c = texture.GetPixels(x - 4, y - 4, 8, 8);
                for (int i = 0; i < c.Length; i++)
                {
                    c[i].a = 0.0f;
                }
                texture.SetPixels(x - 4, y - 4, 8, 8, c);
                //apply
                texture.Apply();
                GetComponent<Renderer>().material.mainTexture = texture;
            }
        }
        
    }

}
