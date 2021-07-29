using NFSDK;
using UnityEngine;

public class NFModelPartControl : MonoBehaviour
{
    public int PartId = -1;

    private Color HoverColor = Color.white;
    private Color SelectedColor = Color.green;
    private Color SharedHoverColor = Color.gray;
    private Color SharedSelectedColor = Color.cyan;

    private NFSceneModule mSceneModule;

    private Outline Otl = null;
    private NFModelInput ModelInput = null;
    private bool IsSelected = false;

    private bool IsSharedHovered = false;
    private bool IsSharedSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        mSceneModule = NFRoot.Instance().GetPluginManager().FindModule<NFSceneModule>();
        GameObject xModelObject = mSceneModule.GetModelObject();
        ModelInput = xModelObject.GetComponent<NFModelInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Otl)
            Otl = gameObject.GetComponent<Outline>();
        if (Otl.OutlineColor != HoverColor)
            Otl.OutlineColor = HoverColor;
        if (IsSelected)
        {
            Otl.enabled = true;
            Otl.OutlineColor = SelectedColor;
        }
        if (IsSharedHovered)
        {
            Otl.enabled = true;
            Otl.OutlineColor = SharedHoverColor;
        }
        if (IsSharedSelected)
        {
            Otl.enabled = true;
            Otl.OutlineColor = SharedSelectedColor;
        }
    }

    public void SetPartId(int id)
    {
        PartId = id;
    }

    public void SetSharedHover(bool tag)
    {
        IsSharedHovered = tag;
    }
    public void SetSharedSelect(bool tag)
    {
        IsSharedSelected = tag;
    }

    public void OnMouseEnter()
    {
        Otl.enabled = true;
        ModelInput.HoverPart(PartId);
    }
    public void OnMouseExit()
    {
        Otl.enabled = false;
        ModelInput.UnhoverPart(PartId);
    }

    public void OnMouseUp()
    {
        IsSelected = !IsSelected;
        if (IsSelected)
            ModelInput.SelectPart(PartId);
        else
            ModelInput.UnselectPart(PartId);
    }
}
