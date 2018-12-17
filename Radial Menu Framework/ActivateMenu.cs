using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ActivateMenu : MonoBehaviour
{
    bool one_click = false;
    bool timer_running;
    float timer_for_double_click;
    public GameObject startMenu;
    public GameObject graphicalMenu;
    public GameObject actionsMenu;
    int hierarchyLevel;

    //this is how long in seconds to allow for a double click
    float delay;

    // Use this for initialization
    void Start()
    {
        delay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            back();
        }
        if (Input.GetMouseButtonDown(1))
        {

            if (!one_click) // first click no previous clicks
            {
                // if(graphicalMenu.activeSelf || actionsMenu.activeSelf || startMenu.activeSelf){
                //         back();
                // }else{
                one_click = true;

                timer_for_double_click = Time.time; // save the current time
                // }
            }
            else
            {
                one_click = false; // found a double click, now reset
                var positionX = Input.mousePosition[0];
                var positionY = Input.mousePosition[1];

                if (positionY < 200)
                {
                    positionY = 200;
                }
                if (positionY > 535)
                {
                    positionY = 535;
                }
                if (positionX < 200)
                {
                    positionX = 200;
                }
                if (positionX > 1330)
                {
                    positionX = 1330;
                }

                //startMenu.transform.localPosition = new Vector3(positionX-650, positionY-300, 0);
                //graphicalMenu.transform.localPosition = new Vector3(positionX-650, positionY-300, 0);
                //actionsMenu.transform.localPosition = new Vector3(positionX-650, positionY-300, 0);
                startMenu.transform.position = new Vector3(positionX, positionY, 0);
                graphicalMenu.transform.position = new Vector3(positionX, positionY, 0);
                actionsMenu.transform.position = new Vector3(positionX, positionY, 0);
                print(startMenu.transform.position);
                if (!(graphicalMenu.activeSelf || actionsMenu.activeSelf))
                {
                    startMenu.SetActive(true);
                }
            }
        }
        if (one_click)
        {
            // if the time now is delay seconds more than when the first click started. 
            if ((Time.time - timer_for_double_click) > delay)
            {

                //basically if thats true its been too long and we want to reset so the next click is simply a single click and not a double click.

                one_click = false;

            }
        }
    }
    public void showGraphicToolsMenu()
    {
        startMenu.SetActive(false);
        graphicalMenu.SetActive(true);
        actionsMenu.SetActive(false);
    }
    public void showActionsMenu()
    {
        startMenu.SetActive(false);
        graphicalMenu.SetActive(false);
        actionsMenu.SetActive(true);
    }
    public void back()
    {
        if (graphicalMenu.activeSelf || actionsMenu.activeSelf)
        {
            startMenu.SetActive(true);
            graphicalMenu.SetActive(false);
            actionsMenu.SetActive(false);
            hierarchyLevel = 0;
        }
        else if (startMenu.activeSelf)
        {
            startMenu.SetActive(false);
        }
    }
    public void disableAll()
    {
        startMenu.SetActive(false);
        graphicalMenu.SetActive(false);
        actionsMenu.SetActive(false);
    }
    public void startPaint()
    {
        disableAll();
        //System.Diagnostics.Process.Start("explorer.exe", "/select," + "C:/WINDOWS/system32/mspaint");

        //EditorUtility.RevealInFinder("C:/WINDOWS/system32/mspaint");
        System.Diagnostics.Process.Start("mspaint.exe");
    }
    public void startHomeFolder()
    {
        disableAll();
        //System.Diagnostics.Process.Start("explorer.exe", "/select," + "C:/Users/ahmed");
        EditorUtility.RevealInFinder("C:/Users/ahmed/Documents");
    }
    public void startNotepad()
    {
        disableAll();
        System.Diagnostics.Process.Start("notepad.exe");
    }

}
