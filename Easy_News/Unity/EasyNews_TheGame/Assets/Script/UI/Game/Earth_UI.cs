using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth_UI : MonoBehaviour
{
    public float rayDistance;
    public Color[] colors;
    public string[] region_name;



    public List<(Color, int)> region_list = new List<(Color, int)>();


    public Texture2D imageMap;
   
    public GameObject ButtonCityPrefab;

   

    [HideInInspector]
    public GameObject data;
    public GameObject RegionNametext;
    public GameObject ButtonCityParent;

    void Start()
    {
        
        data = GameObject.Find("Data_Object");
        RegionNametext = GameObject.Find("Region");
        ButtonCityParent = GameObject.Find("VilleList");
        CreateRegionColorList();
      
    }

    void Update()
    {   
        SelectRegion();
    }

    
    private void SelectRegion() /* Selection d'une région */
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, rayDistance))
        {

            Renderer renderer = hit.transform.GetComponent<MeshRenderer>();
            Texture2D texture = renderer.material.mainTexture as Texture2D;

            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= texture.width;
            pixelUV.y *= texture.height;


            Vector2 tilling = renderer.material.mainTextureScale;
            Color color = imageMap.GetPixel(Mathf.FloorToInt(pixelUV.x * tilling.x), Mathf.FloorToInt(pixelUV.y * tilling.y));

            int region_id = FindIndexColor(color);
            Country selectedRegion =data.GetComponent<monde_data>().FindCountryById(region_id);
            if (region_id >= 0)
            {
                DiplayRegionData(selectedRegion);
              
                
            }
        }
    }

    private int FindIndexColor(Color color)  /* Recherche de l'id auquel correspond la couleur*/
    {
        for (int i = 0; i < region_list.Count; i++)
        {
            (Color tmp_color, int id) = region_list[i];
            if(tmp_color == color)
            {
                return id;
            }
        }
        return -1;
    }

    public void CreateRegionColorList() /* ajout des couleurs et de leur id dans la list */
    {
        World world = data.GetComponent<monde_data>().TheWorld;
       
        for(int i = 0; i < world.CountryList.Count; i++)
        {
            Country country = world.CountryList[i];
            Color newColor;
            ColorUtility.TryParseHtmlString(country.CountryColor, out newColor);
            region_list.Add((newColor, country.Id));
        }
    }

    private void DiplayRegionData(Country selectedRegion)
    {
        RemoveAllChildren(ButtonCityParent);
        RegionNametext.GetComponentInChildren<Text>().text = "Region: \n " + selectedRegion.Name;
        float yPosition = ButtonCityParent.transform.position.y;
        for (int i = 0; i < selectedRegion.CityList.Count; i++)
        {
           
            GameObject tmp = Instantiate(ButtonCityPrefab, ButtonCityParent.transform);
            yPosition -= 30;
            Vector3 tmpPosition = new Vector3(ButtonCityParent.transform.position.x, yPosition, ButtonCityParent.transform.position.z);
            tmp.transform.position = tmpPosition;


            tmp.GetComponentInChildren<Text>().text = selectedRegion.CityList[i].Name;
        }
    }

    private void RemoveAllChildren(GameObject obj) /* delete tous les enfant d'un gameobject parent*/
    {
        
        int nbChildren = obj.transform.childCount;
        for(int i = 0; i < nbChildren; i++)
        {
            Destroy(obj.transform.GetChild(i).gameObject);
        }
    }
}
