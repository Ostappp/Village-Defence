using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject _closeButton;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private InteractionBtns _interactionBtns;
    [SerializeField]
    private SubmitChnagesUI _submitChanges;

    [Header("Structure")]
    [SerializeField]
    private Structure _structure;

    private SubmitWindowType _submitWindowType;

    private void Initialize()
    {
        //set structure name
        _label.text = _structure.GetName;

        //set aviability to upgrade
        if (_structure.GetUpgradeData)
        {
            _interactionBtns.Upgrade.enabled = true;
        }
        else
        {
            _interactionBtns.Upgrade.enabled = false;
        }     

        //Set propper order of active windows
        _interactionBtns.Panel.SetActive(true);
        _submitChanges.Panel.SetActive(false);

        _submitWindowType = SubmitWindowType.None;
    }

    public void SetStructure(Structure structure)
    {
        _structure = structure;
        Initialize();
    }

    public void PressCloseButton()
    {
        Destroy(this);
    }

    public void PressInfoBtn()
    {
        //Change windows
        _interactionBtns.Panel.SetActive(false);
        _submitChanges.Panel.SetActive(true);

        _submitChanges.Description.text = _structure.GetDescription;

        _submitWindowType = SubmitWindowType.Info;
    }
    public void PressUpgradeBtn()
    {
        //Change windows
        _interactionBtns.Panel.SetActive(false);
        _submitChanges.Panel.SetActive(true);

        _submitChanges.Description.text = _structure.GetUpgradeData.GetDescription;

        _submitWindowType = SubmitWindowType.Upgrade;
    }
    public void PressDestroyBtn()
    {
        //Change windows
        _interactionBtns.Panel.SetActive(false);
        _submitChanges.Panel.SetActive(true);

        string message = $"The object <{_structure.GetName}> will be destroyed. You will receive: \n{Values.GetResourceAmount(_structure.GetDestructionCompensation)}";
        _submitChanges.Description.text = message;

        _submitWindowType = SubmitWindowType.Destroy;
    }

    public void PressBackButton()
    {
        //Change windows
        _interactionBtns.Panel.SetActive(true);
        _submitChanges.Panel.SetActive(false);

        _submitWindowType = SubmitWindowType.None;
    }

    public void PressSubmitButton()
    {
        if (_submitWindowType == SubmitWindowType.Info)
            PressBackButton();
        else if (_submitWindowType == SubmitWindowType.Upgrade)
        {
            // upgrade object
        }
        else
        {
            // destroy object
        }

        _submitWindowType = SubmitWindowType.None;
    }

    [System.Serializable]
    private struct InteractionBtns
    {
        public GameObject Panel;
        public Button Info_Use;
        public Button Upgrade;
        public Button Destroy;
    }

    [System.Serializable]
    private struct SubmitChnagesUI
    {
        public GameObject Panel;
        public TMP_Text Description;
    }

    private enum SubmitWindowType
    {
        None,
        Info,
        Upgrade,
        Destroy
    }
}
