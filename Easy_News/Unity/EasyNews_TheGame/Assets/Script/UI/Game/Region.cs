using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    // Start is called before the first frame update
    public float rayDistance;
    public Color[] colors;
    public string[] texts;

    public Texture2D imageMap;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, rayDistance))
        {
         
            Renderer renderer = hit.transform.GetComponent<MeshRenderer>();
            Texture2D texture = renderer.material.mainTexture as Texture2D;

           // Debug.Log(hit.textureCoord);
            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= texture.width;
            pixelUV.y *= texture.height;

            Vector2 tilling = renderer.material.mainTextureScale;
            Color color = imageMap.GetPixel(Mathf.FloorToInt(pixelUV.x * tilling.x), Mathf.FloorToInt(pixelUV.y * tilling.y));


            int index = FindIndexColor(color);
            if (index >= 0)
            {
                Debug.Log(texts[index]);
            }
        }
    }   

    private int FindIndexColor(Color color)
    {
        //Debug.Log(ColorUtility.ToHtmlStringRGB(color));   
        for(int i = 0; i < colors.Length; i++)
        {
            if(colors[i] == color)
            {
                return i;
            }
        }
        return -1;
    }

    
 
}
