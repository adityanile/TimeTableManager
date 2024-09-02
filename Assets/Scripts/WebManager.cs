using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    public string host = "https://time-table-manager-livid.vercel.app/";

    //Paths
    private string getSubjects = "api/getSubjects";
    private string deleteSubject = "api/deleteSubject";
    private string addSubject = "api/addSubject";

    public WebManager instance;
        
    private void Start()
    {
        //StartCoroutine(FetchSubjects("Monday", "Ketan Desale", (e) =>
        //{
        //    Debug.Log(e);

        //}));

        //AddSubjectPayload subject = new AddSubjectPayload();

        //subject.name = "Toc";
        //subject.length = 1;
        //subject.startTime = "10:00am";
        //subject.division = "D-3";
        //subject.branch = "Comp Engg";
        //subject.classroom = "6205";
        //subject.dayofWeek = "Monday";
        //subject.teacherName = "Ketan Desale";

        //StartCoroutine(AddSubject(subject, (e) =>
        //{
        //    Debug.Log(e);

        //}));


        // Creating a static class instance
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
        return;
    }

    // This method will take day and teacher name with a callback which result of the web request
    public IEnumerator FetchSubjects(string day, string teachersName, Action<string> callback)
    {
        GetSubjectPayload payload = new GetSubjectPayload();
        payload.Day = day;
        payload.TeacherName = teachersName;

        string body = JsonUtility.ToJson(payload);

        using(UnityWebRequest webreq = UnityWebRequest.Post(host + getSubjects, body, "application/json"))
        {
            yield return webreq.SendWebRequest();

            string res = string.Empty;

            if(webreq.result == UnityWebRequest.Result.Success)
            {
                res = webreq.downloadHandler.text;
            }
            else
            {
                res = "Error Fetching Subjects Data";
            }
            callback(res);
        }
    }

    public IEnumerator AddSubject(AddSubjectPayload subject, Action<string> callback)
    {
        string body = JsonUtility.ToJson(subject);

        using (UnityWebRequest webreq = UnityWebRequest.Post(host + addSubject, body, "application/json"))
        {
            yield return webreq.SendWebRequest();

            string res = string.Empty;

            if (webreq.result == UnityWebRequest.Result.Success)
            {
                res = webreq.downloadHandler.text;
            }
            else
            {
                res = "Connection Issue";
            }
            callback(res);
        }
    }

}
