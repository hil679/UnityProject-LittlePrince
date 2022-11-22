using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    // Start is called before the first frame update
    public void MainMenu_clicked()
    {
        MainMenu.SetActive(true);
    }

    public void MainMenu_back_clicked()
    {
        MainMenu.SetActive(false);
    }
}
