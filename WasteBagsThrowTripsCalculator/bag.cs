public class bag
{
    public int Id { get; set; }
    public float Weight { get; set; }

    public override string? ToString()
    {
        return $"(Id:{Id},Weight:{Weight})";
    }
}