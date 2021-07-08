public class NFModelInfo
{
    public string mName;

    public NFModelInfo(NFMsg.ModelInfoUnit infoUnit)
    {
        mName = infoUnit.Name.ToStringUtf8();
    }
}
