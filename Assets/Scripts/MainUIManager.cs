using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public TextMeshProUGUI tName;
    public Slider Slider;
    public TextMeshProUGUI workhour;

    private int totalWorking = 9; //9hr total work

    private List<GameObject> generatedSubs = new List<GameObject>();
    public GameObject entryPref;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        tName.text = ApplicationManager.instance.teacherName;
        Init();
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        CalulateWorkLoad();
        GenerateSubjects();
    }


    // Generate cards from the subjects list
    void GenerateSubjects()
    {
        // Clean up 
        foreach(var i in generatedSubs)
        {
            Destroy(i.gameObject);
        }
        generatedSubs.Clear();

        foreach(var s in ApplicationManager.instance.subjects)
        {
            GameObject inst = Instantiate(entryPref, parent);
            EntryManager entryManager = inst.GetComponent<EntryManager>();
            entryManager.SetEntryData(s.id, s.name, s.startTime, ((int)s.length).ToString(),s.branch,s.division,s.classroom);

            generatedSubs.Add(inst);
        }
    }


    // Calculate and add workload to the slider ui
    void CalulateWorkLoad()
    {
        float sum = 0;

        foreach(var s in ApplicationManager.instance.subjects)
        {
            sum += s.length;
        }
        Slider.value = sum/totalWorking;
        workhour.text = $"Today's Workload : {sum} : {totalWorking} hr";
    }
}
