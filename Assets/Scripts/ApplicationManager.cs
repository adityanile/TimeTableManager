using System;
using System.Collections.Generic;
using System.IO;
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


    // Managing Local storage for the application
    public void SaveToLocalStorage(string Tname, Action OnSuccess)
    {
        string path = Path.Join(Application.persistentDataPath, "initial.json");

        LocalStorageModel local = new LocalStorageModel();
        local.tName = Tname;

        string json = JsonUtility.ToJson(local, true);
        File.WriteAllText(path, json);

        OnSuccess();
    }

    public string LocalTeacherName()
    {
        string path = Path.Join(Application.persistentDataPath, "initial.json");

        if (File.Exists(path))
        {
            string text = File.ReadAllText(path);
            LocalStorageModel model = JsonUtility.FromJson<LocalStorageModel>(text);

            return model.tName;
        }
        else
            return string.Empty;
    }

}
