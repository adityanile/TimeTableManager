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

        // Intialising Data for main application
        ApplicationManager.instance.teacherName = tName;
        ApplicationManager.instance.dayofweek = day;

        StartCoroutine(ShowMsg("Loading..."));

        StartCoroutine(WebManager.instance.FetchSubjects(day, tName, (s) =>
        {
            // When we get subject data then
            ApplicationManager.instance.InitSubjects(s, (m) =>
            {
                StartCoroutine(ShowMsg(m));
            }, OnSuccess: () =>
            {
                initialUI.SetActive(false);
                mainUI.SetActive(true);
            });

        }));
    }

    public void EnableAddSubjectsUI()
    {
        mainUI.SetActive(false);
        AddlecUi.SetActive(true);
    }

    public IEnumerator ShowMsg(string m)
    {
        msg.text = m;
        yield return new WaitForSeconds(3);
        msg.text = "";
    }


}
