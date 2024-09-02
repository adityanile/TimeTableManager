using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject initialUI;
    public TMP_InputField teacherName;

    public TextMeshProUGUI msg;

    public void GetSubjects()
    {
        string tName = teacherName.text;
        string day = DateTime.Now.DayOfWeek.ToString();

        StartCoroutine(ShowMsg("Loading..."));

        StartCoroutine(WebManager.instance.FetchSubjects(day, tName, (s) =>
        {
            // When we get subject data then
            ApplicationManager.instance.InitSubjects(s, (m) =>
            {
                StartCoroutine(ShowMsg(m));   
            });

        }));
    }

    IEnumerator ShowMsg(string m)
    {
        msg.text = m;
        yield return new WaitForSeconds(3);
        msg.text = "";
    }


}
