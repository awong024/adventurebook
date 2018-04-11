using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages Player Equipment and Inventory
public class InventoryManager {
    
    //Equipment
    private Equipment equippedLeftWield;
    private Equipment equippedRightWield;
    private Equipment equippedHead;
    private Equipment equippedBody;
    private Equipment equippedBoots;
    private List<Equipment> equippedRelics;

    //Inventory
    private List<ConsumableItem> inventoryItems;
}
