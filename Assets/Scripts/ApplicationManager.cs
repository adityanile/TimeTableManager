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

    public void InitSubjects(string subjectsJson)
    {
        subjectsJson = "[{\"id\":5,\"name\":\"Toc\",\"length\":1,\"startTime\":\"10:00am\",\"division\":\"D-3\",\"branch\":\"Comp Engg\",\"teachername\":\"Ketan Desale\",\"classroom\":\"6205\",\"dayofweek\":\"Monday\"}]";
        var subjects = JsonUtility.FromJson<IEnumerable<SubjectData>>(subjectsJson);
        Debug.Log(subjects);
    }
}
