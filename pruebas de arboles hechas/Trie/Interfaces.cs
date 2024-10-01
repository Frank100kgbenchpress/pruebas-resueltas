namespace Trie
{
    public interface ITrie
    {
        //Raíz del Trie. Representa el caracter vacío 
        NodoTrie Raiz { get; }

        //Añade una nueva palabra al Trie 
        void AgregarPalabra(string palabra);

        //Prefijo común de mayor cantidad de caracteres entre 
        //todas las palabras del Trie 
        string MayorPrefijoComun();

        //Palabras en el Trie que tienen el prefijo especificado 
        IEnumerable<string> PalabrasConPrefijo(string prefijo);

        //Verifica si la palabra está o no en el Trie 
        bool Contiene(string palabra);

        //Vacía el Trie 
        void Vaciar();

        //Cantidad de palabras almacenadas en el Trie 
        int CantidadDePalabras { get; }

        //Indexer para acceder al nodo hijo de la Raíz que corresponda a ese caracter. 
        //De no existir devuelve null 
        NodoTrie this[char valor] { get; }
    }
}