using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Attribute {
    Strength,
    Dexterity,
    Intellect,
    Charisma
}

public class CharacterSheet : MonoBehaviour {
    //View
    [SerializeField] Text strengthLabel;
    [SerializeField] Text dexterityLabel;
    [SerializeField] Text intellectLabel;
    [SerializeField] Text charismaLabel;

    //Base Attribute Stats
    const int BASE_STRENGTH = 6;
    const int BASE_DEXTERITY = 6;
    const int BASE_INTELLECT = 6;
    const int BASE_CHARISMA = 6;

    private int strength;
    private int dexterity;
    private int intellect;
    private int charisma;

    //Accessors
    public int Strength     { get { return strength; } }
    public int Dexterity    { get { return dexterity; } }
    public int Intellect    { get { return intellect; } }
    public int Charisma     { get { return charisma; } }

    //Equipment & Items
    private InventoryManager inventoryManager;

    //Buffs and Effects

    private bool initialized = false;

    private void OnEnable() {
        if (!initialized) {
            InitBaseAttributes();
        } else {
            Render();
        }
    }

	public void InitBaseAttributes() {
        strength = BASE_STRENGTH + UnityEngine.Random.Range(-2, 3);
        dexterity = BASE_DEXTERITY + UnityEngine.Random.Range(-2, 3);
        intellect = BASE_INTELLECT + UnityEngine.Random.Range(-2, 3);
        charisma = BASE_CHARISMA + UnityEngine.Random.Range(-2, 3);

        initialized = true;
        Render();
    }

	private void Render() {
        strengthLabel.text = Strength.ToString();
        dexterityLabel.text = Dexterity.ToString();
        intellectLabel.text = Intellect.ToString();
        charismaLabel.text = Charisma.ToString();
	}
}
