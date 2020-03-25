using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monde_data : MonoBehaviour
{
    public List<Country> coutry_list = new List<Country>();


    
    void Start()
    {
        /*List<Infrastructure> infra_nunk = new List<Infrastructure>();
        List<City> city_list = new List<City>();
        City Nunk = new City(0, "Nunk", 0, 0, 0, 0, false, infra_nunk);
        Country GroenLand = new Country(coutry_list.Count, "Groenland et Island", city_list);
        coutry_list.Add(GroenLand);*/
    }  
}

public class Country
{
    int id;
    string name;
    int climat;
    List<City> city_list;
    public Country(int id, string name, List<City> city_list)
    {
        this.id = id;
        this.name = name;
        this.city_list = city_list;
    }
}


public class City
{
    int id;
    string name;
    int pop_total;
    int pop_infecte;
    int pop_mort;
    int revenu;
    bool researchCenter;
    List<Infrastructure> infra_list;

    public City(int id, string name, int pop_total, int pop_infecte, int pop_mort, int revenu, bool researchCenter, List<Infrastructure> infra_list)
    {
        this.id = id;
        this.name = name;
        this.pop_total = pop_total;
        this.pop_infecte = pop_infecte;
        this.pop_mort = pop_mort;
        this.revenu = revenu;
        this.researchCenter = researchCenter;
        this.infra_list = infra_list;
    }
}

public class Infrastructure
{
    int id;
    int typeId;
    bool construit;
    bool status;
    bool researchCenter;

    public Infrastructure(int id, int typeId, bool construit, bool status, bool researchCenter)
    {
        this.id = id;
        this.typeId = typeId;
        this.construit = construit;
        this.status = status;
        this.researchCenter = researchCenter;
    }
}
