using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject initialUI;
    public GameObject mainUI;

    public TMP_InputField teacherName;

    public GameObject AddlecUi;

    public TextMeshProUGUI msg;

    public static UIManager instance;

    void Start()
    {
        // Here Retrieve teacher's Name in local storage
        teacherName.text = ApplicationManager.instance.LocalTeacherName();

        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
        return;
    }


    public void GetSubjects()
    {
        string tName = teacherName.text;
        string day = DateTime.Now.DayOfWeek.ToString();

        // Remove white spaces
        tName = tName.Trim();

        if (tName != "")
        {
            // Intialising Data for main application
            ApplicationManager.instance.teacherName = tName;
            ApplicationManager.instance.dayofweek = day;

            ShowMsg("Loading...");
            
            tName = tName.ToLower();

            StartCoroutine(WebManager.instance.FetchSubjects(day, tName, (s) =>
            {
                // When we get subject data then
                ApplicationManager.instance.InitSubjects(s, (m) =>
                {
                    ShowMsg(m);
                }, OnSuccess: () =>
                {
                    ApplicationManager.instance.SaveToLocalStorage(teacherName.text, () =>
                    {

                    });

                    initialUI.SetActive(false);
                    mainUI.SetActive(true);
                });

            }));
        }
        else
        {
            ShowMsg("Enter Teacher Name");
        }
    }

    public void EnableAddSubjectsUI()
    {
        mainUI.SetActive(false);
        AddlecUi.SetActive(true);
    }

    public void ShowMsg(string msg)
    {
        StartCoroutine(DisplayMsg(msg));
    }

    IEnumerator DisplayMsg(string m)
    {
        msg.text = m;
        yield return new WaitForSeconds(3);
        msg.text = "";
    }


}
