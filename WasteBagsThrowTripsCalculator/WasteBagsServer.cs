public class WasteBagsServer
{
    private float _maxWeight = 0;
	private List<List<bag>> _output;
    private List<bag> _bagsStillNeedToThrow;

    public WasteBagsServer(List<bag> input, float maxWeight)
    {
        _bagsStillNeedToThrow = input;
        _output = new List<List<bag>>();
        _maxWeight = maxWeight;
    }

    public override string? ToString()
    {
        return $"Trips:{_output}";
    }

    public List<List<bag>> CalculateTrips(int optionsSpliter = 1)
    {
        var generatedOptions = generateOptions(_bagsStillNeedToThrow, optionsSpliter);
        var filteredValidOptions = filterValidOptions(generatedOptions);
        if(filteredValidOptions == null)
        {
            CalculateTrips(++optionsSpliter);
        }
        var bestOption = takeBestOption(filteredValidOptions, _maxWeight);
        _bagsStillNeedToThrow = getBagsStillNeedToThrow(_bagsStillNeedToThrow, bestOption);
        if (_bagsStillNeedToThrow.Count() == 0)
        {
            return _output;
        }
        else
        {
            CalculateTrips();
        }
        return _output;
    }

    private List<List<bag>> generateOptions(List<bag> bagsStillNeedToThrow, int optionsSpliter)
    {
        return null;
    }

    private List<List<bag>> filterValidOptions(List<List<bag>> bagsOptions, float maxWeight = 3)
        => bagsOptions.Where(options=>options.Sum(x=>x.Weight) <= maxWeight).ToList();

    private List<bag> takeBestOption(List<List<bag>> bagsOptions, float maxWeight = 3)
    {
        var maxvalidWeight = 0.0;
        List<bag> bestOption = null;
        Parallel.ForEach(bagsOptions, (option) =>
        {
            var sumWeight = option.Sum(x => x.Weight);
            if (sumWeight > maxvalidWeight)
            {
                maxvalidWeight = sumWeight;
                bestOption = option;
            }
        });
        return bestOption;
    }

    private List<bag> getBagsStillNeedToThrow(List<bag> bagsStillNeedToThrow, List<bag> takenBestOption)
    {
        // update bagsNeedToThrow
        var stillNeedToThrow = bagsStillNeedToThrow.Where(bag => !takenBestOption.Contains(bag)).ToList();
        // update _output
        if(takenBestOption != null)
        {
            _output.Add(takenBestOption);
        }
        return stillNeedToThrow;
    }

}