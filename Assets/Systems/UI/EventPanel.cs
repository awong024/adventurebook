using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : Panel {
    [SerializeField] Text titleLabel;
    [SerializeField] Image environmentImage;
    [SerializeField] Text eventDescription;

    [SerializeField] Button proceedButton;
    [SerializeField] Button dismissButton;

    private Event currentEvent;

    private bool eventFinished = false;

	public override void Display() {
        base.Display();
	}

    public override void Dismiss() {
        base.Dismiss();
    }

    public void Render(Event nodeEvent) {
        currentEvent = nodeEvent;

        titleLabel.text = currentEvent.EnvironmentType.ToString();
        //Render Environment Art
        //Render Event Description
        if (currentEvent.Activity is Encounter) {
            eventDescription.text = "Encounter";
        } else if (currentEvent.Activity is Merchant) {
            eventDescription.text = "Merchant";
        } else if (currentEvent.Activity is Challenge) {
            eventDescription.text = "Challenge";
        }
        eventFinished = false;
        SetButtons();
    }

    public void ProceedClicked() {
        bool success = currentEvent.ProcessEvent();
        eventFinished = true;

        eventDescription.text = success.ToString() + "!";

        SetButtons();

        GameManager.EventCompleted();
    }

    private void SetButtons() {
        dismissButton.gameObject.SetActive(eventFinished);
        proceedButton.gameObject.SetActive(!eventFinished);
    }

}
