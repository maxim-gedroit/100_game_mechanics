public class BoxEngine : BaseObject
{
    private void Start()
    {
        if (gameObject.name == "BoxEngineEntry")
        {
            Connect(true);
        }
    }
}
