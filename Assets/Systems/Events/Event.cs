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
public class Event
{
    private EnvironmentType environmentType;
    private List<Activity> activities = new List<Activity>(); //For now, only one Activity
    private Challenge challenge;

    //Accessors
    public EnvironmentType EnvironmentType { get { return environmentType; } }
    public Activity Activity { get { return activities[0]; } }
    public Challenge Challenge { get { return challenge; } }


    //Town = Merchant / Rest
    //Wild = Encounter
    //Ruins = Explore Challenge
    public void GenerateTownEvent(Challenge challenge) {
        environmentType = EnvironmentType.Town;
        this.challenge = challenge;
    }

    public void GenerateWildEvent(Challenge challenge) {
        environmentType = EnvironmentType.Wild;
        this.challenge = challenge;
    }

    public void GenerateRuinsEvent(Challenge challenge) {
        environmentType = EnvironmentType.Ruins;
        this.challenge = challenge;
    }

    public void Init(EnvironmentType environment, Activity activity) {
        environmentType = environment;
        activities.Add(activity);
    }

    public bool ProcessEvent() {
        return true;
    }
}