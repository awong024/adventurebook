using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {
    [SerializeField] EventPanel eventPanel;

    private static PanelManager instance;

    private void Awake() {
        instance = this;
	}

	public static void DisplayEventPanel(Event nodeEvent) {
        instance.DisplayPanel(instance.eventPanel);
        instance.eventPanel.Render(nodeEvent);
    }

    private void DisplayPanel(Panel panel) {
        panel.gameObject.SetActive(true);
        panel.Display();
    }

    private void DismissPanel(Panel panel) {
        panel.Dismiss();
    }

    public static bool PlayPeepleToEvent(PeepleFigurine peeple) {
        return instance.eventPanel.ContributePeeple(peeple);
    }
}
