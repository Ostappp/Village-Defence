using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Values;

public class BuildElementUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;
    [SerializeField]
    private RawImage _image;
    [SerializeField]
    private TMP_Text _description;

    public void SetBuildingUIData(Texture img, string title, string description, IEnumerable<Resource> price)
    {
        _image.texture = img;
        _title.text = title;

        StringBuilder sb = new();
        sb.AppendLine(description);
        sb.AppendLine(GetResourceAmount(SummarizeResources(price)));
        _description.text = sb.ToString();
    }
}
