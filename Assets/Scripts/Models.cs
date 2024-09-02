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
    public string dayofWeek;
}

[System.Serializable]
public class GetSubjectPayload
{
    public string Day;
    public string TeacherName;
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

    public string status;
    public string msg;

    // Error Message if fail
    public string e;
}

[System.Serializable]
public class DeleteResponse
{
    public string status;
    public string msg;

    // Error Message if fail
    public string e;
}

