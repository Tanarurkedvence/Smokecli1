namespace Smokecli1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Resident> residents = new List<Resident>();
             
            using(StreamReader olvasunk = new StreamReader("../../../Forras/smoking.txt"))
            {
                olvasunk.ReadLine();
                while (!olvasunk.EndOfStream)
                {
                    string line = olvasunk.ReadLine();
                    residents.Add(new Resident(line));


                }
            }
            Console.WriteLine("5 fedaldat");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(residents[i].ToString());
            }
            
            Console.WriteLine("6. feladat");
            var f6 = residents.Where(x => x.Smoke == "Yes"
            && x.Nationality.NationalityName == "British"
            && x.MaritalStatus == "Married"
            && x.Gender == "Male"
            && !x.GrossIncome.Contains("Under")
            && !x.GrossIncome.Contains("Above")
            && !x.GrossIncome.Contains("Refused"));

            foreach(var faszocska in f6)
            {
                Console.WriteLine(faszocska.ToString());
            }
            if(f6.Any())
            {
                var finglingi = f6.Select(x =>
                {
                    var income = x.GrossIncome.Split(" to ");
                    int max = int.Parse(income[1]);
                    return max;
                }).Max();
                Console.WriteLine($"\nA leszűrt lakosok maximális jövedelmének maximuma: {finglingi} angol font");
            }
            Console.WriteLine("7. feladat");

            var f7 = residents.Where(x => x.Age >= 25 && x.Age <= 30
            && x.Region == "Wales"
            && x.Smoke == "No").OrderByDescending(x => x.Age);
            using (StreamWriter iro = new StreamWriter("../../../forras/wales.txt"))
            {
                foreach (var f in f7)
                {
                    iro.WriteLine($"{f.Age} {f.Gender} {f.Qualification}");
                }
            }
        }
    }
}
