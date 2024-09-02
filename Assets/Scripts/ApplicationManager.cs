using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager instance;

    [SerializeField]
    public List<SubjectData> subjects = new List<SubjectData>();

    public string teacherName = "";
    public string dayofweek = "";

    // Start is called before the first frame update
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

    public void InitSubjects(string subjectsJson, Action<String> callback, Action OnSuccess)
    {
        if (subjectsJson != null)
        {
            var gotSubjects = JsonUtility.FromJson<GotSubjects>(subjectsJson);

            if (gotSubjects.status.Equals("fail"))
            {
                callback(gotSubjects.msg);
            }
            else
            {
                subjects.AddRange(gotSubjects.subjectData);
                callback("Success !!");
            }
                OnSuccess();
        }
        else
        {
            callback("Error Connecting server");
        }
    }
}
