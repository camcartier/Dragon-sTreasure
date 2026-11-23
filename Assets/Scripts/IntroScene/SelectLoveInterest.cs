using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectLoveInterest : MonoBehaviour
{
    [SerializeField] GameObject characterSelectionPanel;
    public List<GameObject> dialogPanelsList = new List<GameObject>();

    public int index;
    private GameObject buttonSelected;
    private GameObject panelToActivate;

    public void SelectThisChar()
    {
        buttonSelected = EventSystem.current.currentSelectedGameObject;
        int index = buttonSelected.GetComponent<NumberTag>().number;
        Debug.Log(index);

        panelToActivate = dialogPanelsList[index];
        panelToActivate.SetActive(true);
        characterSelectionPanel.SetActive(false);
    }
}
