using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager instance;

    [SerializeField]
    private List<SubjectData> subjects = new List<SubjectData>();

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

    public void InitSubjects(string subjectsJson, Action<String> callback)
    {
        if (subjectsJson != null)
        {
            Debug.Log(subjectsJson);

            var gotSubjects = JsonUtility.FromJson<GotSubjects>(subjectsJson);

            if (gotSubjects.msg.Equals("No Data Found"))
            {
                callback(gotSubjects.msg);
                return;
            }
            else
            {
                subjects.AddRange(gotSubjects.subjectData);
                callback("Success !!");
            }
        }
        else
        {
            callback("Error Connecting server");
        }
    }
}
