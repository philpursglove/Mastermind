namespace Mastermind
{
    public class Codemaker
    {
        public List<string> _code { get; set; }

        public void Initialise(List<string> code)
        {
            _code = code;
        }

        public List<int> Evaluate(List<string> guess){
            //use Code
            var wellPlaced = 0;
            var misPlaced = 0;

            if (_code.Count != guess.Count)
            {
                return null;
            }
            
            //finds well placed colours
            for (int i = 0; i < guess.Count; i++){
                if (guess[i] == _code[i]){
                    wellPlaced++;
                    guess.RemoveAt(i);
                    _code.RemoveAt(i);
                }
            }

            // find misplaced colours
            for (int i = 0; i < guess.Count; i++){
                if (_code.Contains(guess[i])){
                    misPlaced++;
                }
            }

            List<int> output = new List<int> {wellPlaced, misPlaced};

            return output;
        }
    }
}