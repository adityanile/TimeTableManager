using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    public string host = "https://time-table-manager-livid.vercel.app/";

    //Paths
    private string getSubjects = "api/getSubjects";
    private string deleteSubject = "api/deleteSubject";
    private string addSubject = "api/addSubject";

    public static WebManager instance;
        
    private void Start()
    {
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
                res = webreq.downloadHandler.text;
            
            callback(res);
        }
    }

    public IEnumerator AddSubject(AddSubjectPayload subject, Action<string> callback, Action<int> OnSuccess)
    {
        string body = JsonUtility.ToJson(subject);

        using (UnityWebRequest webreq = UnityWebRequest.Post(host + addSubject, body, "application/json"))
        {
            yield return webreq.SendWebRequest();

            string res = string.Empty;

            if (webreq.result == UnityWebRequest.Result.Success)
            {
                res = webreq.downloadHandler.text;

                GotSubjects subjectPayload = new GotSubjects();
                subjectPayload = JsonUtility.FromJson<GotSubjects>(res);

                callback(subjectPayload.status);
                OnSuccess(subjectPayload.subjectID);
            }
            else
            {
                res = "Connection Issue";
                callback(res);
            }
        }
    }

    public IEnumerator DeleteSubject(int id, Action OnSuccess)
    {
       DeletePayload payload = new DeletePayload();
        payload.id = id;

        string body = JsonUtility.ToJson(payload);

        using (UnityWebRequest webreq = UnityWebRequest.Post(host + deleteSubject, body, "application/json"))
        {
            yield return webreq.SendWebRequest();

            string res = string.Empty;

            if (webreq.result == UnityWebRequest.Result.Success)
            {
                res = webreq.downloadHandler.text;

                DeleteResponse response = JsonUtility.FromJson<DeleteResponse>(res);

                if(response.status == "success")
                OnSuccess();
            }

        }
    }

}
