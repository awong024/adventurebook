using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnvironmentType {
    Town,
    Wild,
    Ruins
}

public class Activity {
    
}

//Each Node has one Event
//Events can contain multiple Activities
public class Event {
    private EnvironmentType environmentType;
    private List<Activity> activities = new List<Activity>(); //For now, only one Activity

    //Accessors
    public EnvironmentType EnvironmentType { get { return environmentType; } }
    public Activity Activity { get { return activities[0]; } }

    //Town = Merchant / Rest
    //Wild = Encounter
    //Ruins = Explore Challenge
    public void GenerateTownEvent() {
        environmentType = EnvironmentType.Town;
        activities.Add(new Merchant());
    }

    public void GenerateWildEvent() {
        environmentType = EnvironmentType.Wild;
        activities.Add(new Encounter());
    }

    public void GenerateRuinsEvent() {
        environmentType = EnvironmentType.Ruins;
        activities.Add(new Challenge());
    }

    public bool ProcessEvent() {
        return true;
    }
}