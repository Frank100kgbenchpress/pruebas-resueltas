namespace Trie
{
    public class Trie : ITrie
    {
        public NodoTrie Raiz { get; private set; }

        public NodoTrie this[char valor]
        {
            get
            {
                var match = Raiz.Hijos.Where(x => x.Valor == valor).FirstOrDefault();
                return match!;
            }
        }

        public Trie() =>(Raiz,CantidadDePalabras) = (new NodoTrie('\0'),0);
        public void AgregarPalabra(string palabra) =>    Insert(palabra,Raiz,0);
        public void Insert(string word,NodoTrie nodo,int index)
        {
            if(index == word.Length)
            {
                nodo.FinDePalabra = true;
                CantidadDePalabras ++;
                return;
            }
            var match = nodo.Hijos.Where(x=> x.Valor == word[index]).FirstOrDefault();
            if(match is null)
            {
                var child = new NodoTrie(word[index]);
                nodo.Hijos.Add(child);
                Console.WriteLine($"Added node: {child.Valor}");
                Insert(word,child,index +1);
            }
            else Insert(word,match,index+1);
        }

        public string MayorPrefijoComun()
        {
            string longest = "";
            string prefix = "";
            var collection = PalabrasConPrefijo("");
            if(collection.Count() != 0)
            {
                var first = collection.First();
                for(int i = 0; i <  first.Length ; i++)
                {
                    if(HasPrefix(first[i],i,collection)) longest += first[i];
                    else
                    {
                        Console.WriteLine($"LCP: {longest}");
                        return longest;
                    }
                }
            }
            Console.WriteLine($"LCP: {longest}");
            return longest;
        }

        bool HasPrefix(char letter, int index, IEnumerable<string> collection)
        {
            foreach(var word in collection)
            {
                if(index >= word.Length) return false;
                if(word[index] != letter) return false;
            }
            return true;
        }

        public IEnumerable<string> PalabrasConPrefijo(string prefijo)
        {
            List<string> words = new();
            WordsWithPrefix(Raiz,0,prefijo,words);
            return words;
        }
        void WordsWithPrefix(NodoTrie actual, int index, string prefix, List<string> words)
        {
            if (index == prefix.Length)
            {
                GetWords(actual, prefix, words);
            }
            else
            {
                var match = actual.Hijos.Where(x => x.Valor == prefix[index]).FirstOrDefault();
                if (match is null) return;
                else
                {
                    WordsWithPrefix(match, index + 1, prefix, words);
                }
            }
        }

        void GetWords(NodoTrie actual, string word, List<string> words)
        {
            if (actual.Hijos.Count == 0 && actual.FinDePalabra)
            {
                words.Add(word);
                System.Console.WriteLine($"Added leaf {word}");
                return;
            }

            else if (actual.FinDePalabra && actual.Hijos.Count != 0)
            {
                words.Add(word);
                System.Console.WriteLine($"Added word {word}");

                foreach (var child in actual.Hijos)
                {
                    GetWords(child, word + child.Valor, words);
                }

                return;
            }

            else
            {
                foreach (var child in actual.Hijos)
                {
                    GetWords(child, word + child.Valor, words);
                }
            }
        }

        public bool Contiene(string palabra) => Contains(Raiz, 0, palabra);

        public bool Contains(NodoTrie actual, int index, string word)
        {
            var match = actual.Hijos.Where(x => x.Valor == word[index]).FirstOrDefault();
            if (match is null) return false;
            else if (match.FinDePalabra) return true;
            else
                return Contains(match, index + 1, word);
        }

        public void Vaciar()=>    Raiz.Hijos.Clear();

        public int CantidadDePalabras { get; private set; }
    }   
}