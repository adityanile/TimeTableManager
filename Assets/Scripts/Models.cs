using JetBrains.Annotations;

[System.Serializable]
public class SubjectData
{
    public int id;
    public string name;
    public float length;
    public string startTime;
    public string division;
    public string branch;
    public string teachername;
    public string classroom;
    public string dayofweek;
}

[System.Serializable]
public class GetSubjectPayload
{
    public string Day;
    public string TeacherName;
}

[System.Serializable]
public class GotSubjects
{
    public SubjectData[] subjectData;
    public string msg;
    public string status;
    public int subjectID;
}

[System.Serializable]
public class AddSubjectPayload
{
    public string name;
    public float length;
    public string startTime;
    public string division;
    public string branch;
    public string teacherName;
    public string classroom;
    public string dayofWeek;
}

[System.Serializable]
public class AddedResponse
{
    public int successID;

    public string status;
    public string msg;

    // Error Message if fail
    public string e;
}
[System.Serializable]
public class DeletePayload
{
    public int id;
}

[System.Serializable]
public class DeleteResponse
{
    public string status;
    public string msg;

    // Error Message if fail
    public string e;
}

[System.Serializable]
public class LocalStorageModel
{
    public string tName;
}

