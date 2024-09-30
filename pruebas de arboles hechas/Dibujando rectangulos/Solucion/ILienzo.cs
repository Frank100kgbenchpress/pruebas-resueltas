namespace QUadTreeSolution
{
    public interface ILienzo
    {
    /// <summary>
    /// Devuelve la cantidad de píxeles de la imagen.
    /// </summary>
    int Resolucion { get; }
    /// <summary>
    /// Devuelve la cantidad de nodos de color blancos que tiene el quad-tree.
    /// </summary>
    int CantidadDeNodosBlancos { get; }
    /// <summary>
    /// Devuelve la cantidad de nodos de color negro que tiene el quad-tree.
    /// </summary>
    int CantidadDeNodosNegros { get; }
    /// <summary>
    /// Devuelve la cantidad de nodos grises que tiene el quad-tree.
    /// </summary>
    int CantidadDeNodosGrises { get; }
    /// <summary>
    /// Rellena el rectángulo dado con color negro.
    /// </summary>
    /// <param name="fila">Fila donde comienza el rectángulo</param>
    /// <param name="columna">Columna donde comienza el rectángulo</param>
    /// <param name="ancho">Ancho del rectángulo</param>
    /// <param name="alto">Alto del rectángulo</param>
    void Dibuja(int fila, int columna, int ancho, int alto);
    /// <summary>
    /// Comprueba si un pixel ha sido pintado.
    /// </summary>
    /// <param name="fila">Fila del pixel</param>
    /// <param name="columna">Columna del pixel</param>
    /// <returns>Devuelve true en caso de que el pixel haya sido
    /// pintado, y false en caso contrario.</returns>
    bool EstaPintado(int fila, int columna);
    }
}