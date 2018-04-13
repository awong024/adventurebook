using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeModel : ScriptableObject
{
    [SerializeField] string challengeName;
    [SerializeField] string description;
    [SerializeField] Challenge.Type challengeType;
    [SerializeField] Attribute[] attributeSlots;

    public string ChallengeName { get { return challengeName; } }
    public string Description { get { return description; } }
    public Challenge.Type ChallengeType { get { return challengeType; } }
    public Attribute[] AttributeSlots { get { return attributeSlots; } }
}
