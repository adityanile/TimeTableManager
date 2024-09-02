using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddNewSubject : MonoBehaviour
{
    public TMP_InputField name;
    public TMP_InputField startTime;
    public TMP_InputField division;
    public TMP_InputField department;
    public TMP_InputField classroom;

    public TMP_Dropdown duration;
    public TMP_Dropdown dayOfWeek;

    private void Start()
    {
        Init();
    }
    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        name.text = "";
        startTime.text = "";
        division.text = "";
        department.text = "";
        classroom.text = "";
    }

   public void OnClickAddSubject()
    {
        AddSubjectPayload addsub = new AddSubjectPayload();
        addsub.name = name.text;

        string currsel = duration.options[duration.value].text;
        float.TryParse(currsel[0].ToString(), out addsub.length);

        addsub.startTime = startTime.text;
        addsub.division = division.text;
        addsub.branch = department.text;
        addsub.teacherName = ApplicationManager.instance.teacherName;
        addsub.classroom = classroom.text;

        addsub.dayofWeek = dayOfWeek.options[dayOfWeek.value].text;

        StartCoroutine( WebManager.instance.AddSubject(addsub, (s) =>
        {
            StartCoroutine(UIManager.instance.ShowMsg(s));
        }, OnSuccess : (id)=>
        {
            SubjectData sub = new SubjectData
            {
                id = id,
                name = addsub.name,
                length = addsub.length,
                startTime = addsub.startTime,
                division = addsub.division,
                branch = addsub.branch,
                teachername = addsub.teacherName,
                classroom = addsub.classroom,
                dayofweek = addsub.dayofWeek
            };
            
            ApplicationManager.instance.subjects.Add(sub);

            UIManager.instance.mainUI.SetActive(true);
            UIManager.instance.AddlecUi.SetActive(false);
        }));
    }
}
