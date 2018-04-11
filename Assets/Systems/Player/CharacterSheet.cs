using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute {
    Strength,
    Dexterity,
    Intellect,
    Charisma
}

public class CharacterSheet : MonoBehaviour {
    //Base Attribute Stats
    private Dictionary<int, int> base_attribute_dict = new Dictionary<int, int>();

    const int BASE_STRENGTH = 6;
    const int BASE_DEXTERITY = 6;
    const int BASE_INTELLECT = 6;
    const int BASE_CHARISMA = 6;

    //Accessors
    public int Strength     { get { return base_attribute_dict[(int)Strength]; } }
    public int Dexterity    { get { return base_attribute_dict[(int)Dexterity]; } }
    public int Intellect    { get { return base_attribute_dict[(int)Intellect]; } }
    public int Charisma     { get { return base_attribute_dict[(int)Charisma]; } }

    //Equipment & Items
    private InventoryManager inventoryManager;

    //Peeple Pool

    //Peeple Hand

    //Buffs and Effects

    private void Start() {
        InitBaseAttributeDictionary();
	}

	public void InitBaseAttributeDictionary() {
        base_attribute_dict.Add((int)Strength, BASE_STRENGTH);
        base_attribute_dict.Add((int)Dexterity, BASE_DEXTERITY);
        base_attribute_dict.Add((int)Intellect, BASE_INTELLECT);
        base_attribute_dict.Add((int)Charisma, BASE_CHARISMA);
    }
}
