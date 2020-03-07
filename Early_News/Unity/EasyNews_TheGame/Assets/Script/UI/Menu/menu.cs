using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject select_lvl_pannel;
    public GameObject select_option_pannel;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Open_lvl_selection() // ouvre le menu de selection des niveaux
    {
        select_lvl_pannel.SetActive(true);
        select_option_pannel.SetActive(false);
    }

    public void Open_option_selection() // ouvre le menu de selection des option
    {
        select_lvl_pannel.SetActive(false);
        select_option_pannel.SetActive(true);
    }

    public void QuitGame() // quitte le jeu 
    {
        Application.Quit();
    }

    public void Load_level()
    {
        Application.LoadLevel("game_scene");
    }
    
}
