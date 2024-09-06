using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {

    public GameObject firstSelected;
    public UnityEvent onPanelActivated;

    private void Awake() {
        PanelSwitcher(false);
    }
    public void Activate() {
        SetSelectedGameObject();
        PanelSwitcher(true);
        onPanelActivated.Invoke();
    }

    private void PanelSwitcher(bool isActive) {
        GameObject uiPanel = transform.GetChild(0).gameObject;
        uiPanel.SetActive(isActive);
    }
    private void SetSelectedGameObject() {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
