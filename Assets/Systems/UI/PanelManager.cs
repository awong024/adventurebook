using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {
    [SerializeField] Panel eventPanel;

    private static PanelManager instance;

    private void Awake() {
        instance = this;
	}

	public static void DisplayEventPanel() {
        instance.DisplayPanel(instance.eventPanel);
    }

    private void DisplayPanel(Panel panel) {
        panel.gameObject.SetActive(true);
        panel.Display();
    }

    private void DismissPanel(Panel panel) {
        panel.Dismiss();
    }
}
