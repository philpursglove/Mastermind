namespace Mastermind.Tests
{
    public class Tests
    {
        private Codemaker maker;
        
        [SetUp]
        public void Setup()
        {
            maker = new Codemaker();


        }

        [TestCase("blue", "red", 0, 0, Description = "OnePegMisplaced")]
        [TestCase("blue", "blue", 1, 0, Description = "OnePegWellPlaced")]
        [TestCase("red,red", "red,blue", 1, 0, Description = "DuplicateInSecret")]
        [TestCase("blue,red", "red,red", 1, 0, Description = "DuplicateGuessMisplaced")]
        [TestCase("blue,red,yellow", "blue,blue,yellow", 2, 0, Description = "TwoWellPlacedOneWrong")]

        public void CheckGuess(string codeColours, string guessedColours, int expectedWellPlaced, int expectedMisplaced)
        {
            List<string> code = codeColours.Split(",").ToList();
            List<string> guess = guessedColours.Split(",").ToList();

            maker.Initialise(code);
            var result = maker.Evaluate(guess);

            Assert.That(result.First(), Is.EqualTo(expectedWellPlaced));
            Assert.That(result.Last(), Is.EqualTo(expectedMisplaced));
        }

        [Test]
        public void TestMisplaced()
        {
            maker.Initialise(new List<string>() { "red", "yellow" });

            List<string> guess = new List<string> {"blue", "red"};

            var result = maker.Evaluate(guess);

            Assert.That(result.Last(), Is.EqualTo(1));
        }
    }
}

/*
[red, red] , [blue, red] -> [1, 0]
[blue, red], [red, red] -> [1, 0] // [1,1]
[blue, red, yellow], [blue, blue, yellow] -> [2,0]
*/