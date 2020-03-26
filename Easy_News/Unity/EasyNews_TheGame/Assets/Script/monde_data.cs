using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class monde_data : MonoBehaviour
{
    public World TheWorld;

    
    void Start()
    {
       getWorldDataFromJson("/WorldData");
    }  


    private void getWorldDataFromJson(string file)
    {
        string chemin = Application.streamingAssetsPath + file;
        string jsonString = File.ReadAllText(chemin);
        TheWorld = JsonUtility.FromJson<World>(jsonString);
    }


}
[System.Serializable]
public class World
{
    public List<Country> CountryList;
}


[System.Serializable]
public class Country
{
    public int Id;
    public string Name;
    public int Climat;
    public List<City> CityList;
}

[System.Serializable]
public class City
{
    public int Id;
    public string Name;
    public int PopTotal;
    public int PopInfecte;
    public int PopMort;
    public int Revenu;
    public List<Infrastructure> InfraList;

}
[System.Serializable]
public class Infrastructure
{
    public int Id;
    public int TypeId;
    public int Status;
}

/* status :
 *  0 : non present
 *  1 : en connstruction
 *  2 : ouvert
 *  3 : fermé

 * 
 * */
