public class WasteBagsServer
{
    private List<bag> _input;
	private List<string> _output;
	public WasteBagsServer(List<bag> input)
    {
        _input = input;
        _output = new List<string>();
	}

    public override string? ToString()
    {
        return $"Trips:{_output}";
    }

    public bool CalculateTrips()
    {
        throw new NotImplementedException();
    }

}