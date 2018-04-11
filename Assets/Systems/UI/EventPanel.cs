using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : Panel {
    [SerializeField] Text titleLabel;

	public override void Display() {
        base.Display();
	}

    public void Render(Event nodeEvent) {
        titleLabel.text = nodeEvent.EnvironmentType.ToString();
    }

    public override void Dismiss() {
        base.Dismiss();
	}
}
