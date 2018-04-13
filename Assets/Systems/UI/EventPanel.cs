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

    [SerializeField] GameObject[] peepleSlots;

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

        titleLabel.text = currentEvent.Challenge.ChallengeName;
        //Render Environment Art
        eventDescription.text = currentEvent.Challenge.Description;

        for (int i = 0; i < peepleSlots.Length; i++) {
            peepleSlots[i].SetActive(i < currentEvent.Challenge.AttributeSlots.Length);
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
