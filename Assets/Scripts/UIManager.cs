using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_InputField teacherName;

    public void GetSubjects()
    {
        string tName = teacherName.text;
        string day = DateTime.Now.DayOfWeek.ToString();

        StartCoroutine(WebManager.instance.FetchSubjects(day, tName, (s) =>
        {
            // When we get subject data then
            ApplicationManager.instance.InitSubjects(s);
        }));
    }


}
