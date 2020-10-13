using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityUI : MonoBehaviour
{
    public City city;
    public GameObject VilleUI;
    
    // Start is called before the first frame update
    void Start()
    {
        FindVilleUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FindVilleUI()
    {
        GameObject[] tab = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
        for(int i = 0; i < tab.Length; i++)
        {
            if (tab[i].name == "VilleUI")
            {
                VilleUI = tab[i];
            }
        }
    }

    public void OpenCityInterface()
    {
        VilleUI.SetActive(true);
        VilleUI.GetComponentInChildren<Text>().text = city.Name;

        string CityInfo = "Population Total:" + city.PopTotal + "\n Population Infectée:" + city.PopInfecte + "\n Mort:" + city.PopMort;

        VilleUI.transform.GetChild(1).GetComponent<Text>().text = CityInfo;
    }

  
}
