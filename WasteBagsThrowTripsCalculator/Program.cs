Console.WriteLine("Please Enter the amount of bags, followed by each bag weight");
var bagsAmount = int.Parse(Console.ReadLine());
var inputs = new List<bag>();
for (var i = bagsAmount; i > 0; i--)
{
    inputs.Add(new bag { Id = i, Weight = float.Parse(Console.ReadLine()) });
}

Console.WriteLine(string.Join('>', new WasteBagsServer(inputs).CalculateTrips()));