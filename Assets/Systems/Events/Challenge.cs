using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : Activity {
    public enum Type {
        CombatCheck,
        Explore,
        Town
    }

    private Type challengeType;
    private Attribute[] attributeSlots;

    private string challengeName;
    private string description;

    //Accessors
    public string ChallengeName { get { return challengeName; } }
    public string Description { get { return description; } }
    public Challenge.Type ChallengeType { get { return challengeType; } }
    public Attribute[] AttributeSlots { get { return attributeSlots; } }

    public Challenge(ChallengeModel model) {
        this.challengeType = model.ChallengeType;
        this.attributeSlots = model.AttributeSlots;
        this.challengeName = model.ChallengeName;
        this.description = model.Description;
    }

    public void ProcessReward() {
        
    }
}
