using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntryManager : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI name;
    public TextMeshProUGUI startTime;
    public TextMeshProUGUI duration;
    public TextMeshProUGUI branch;
    public TextMeshProUGUI division;
    public TextMeshProUGUI classroom;

    public void SetEntryData(int id, string name, string time, string duration, string branch,string division, string classroom)
    {
        this.id = id;
        this.name.text = name;
        this.branch.text = branch;
        this.duration.text = duration + " hr";
        this.division.text = division;
        this.classroom.text = "Location: " + classroom;
        this.startTime.text = time;
    }

    public void OnClickDelete()
    {
        StartCoroutine(WebManager.instance.DeleteSubject(this.id, () =>
        {
            SubjectData sub = ApplicationManager.instance.subjects.Find((x) => x.id == this.id);
            ApplicationManager.instance.subjects.Remove(sub);
            
            UIManager.instance.mainUI.SetActive(false);
            UIManager.instance.mainUI.SetActive(true);

            UIManager.instance.ShowMsg("Deletion Successful");
        }));
    }
}
