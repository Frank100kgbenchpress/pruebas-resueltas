// Problema: "El Viaje del Profesor R con obstáculos y tiempo límite"
// Descripción:
// El Profesor R necesita llegar a su casa después de una larga noche de celebración. Vive en un mundo representado por una cuadrícula, pero en esta ocasión no solo hay huecos en el suelo que debe evitar, sino que tiene un tiempo límite para llegar a su casa. Si el Profesor R no llega a su casa dentro del tiempo límite, se perderá en la noche.

// Información adicional:
// El Profesor R comienza en la posición 
// (
// 0
// ,
// 0
// )
// (0,0) del mapa.
// Su casa se encuentra en la posición 
// (
// 𝑖
// ,
// 𝑗
// )
// (i,j) del mapa.
// Hay huecos en el mapa representados por un array bidimensional de booleanos (True indica un hueco, False indica una casilla segura).
// El mundo es circular: si intenta salir de los bordes, reaparecerá por el otro lado.
// El Profesor R está tan borracho que se mueve en saltos de dos casillas hacia adelante en las direcciones cardinales (norte, sur, este, oeste) o en diagonal, moviéndose en forma de "L" similar al caballo en ajedrez.
// Nuevo desafío: El Profesor tiene un tiempo límite de T movimientos. Si no llega a su casa en ese tiempo, el método debe devolver -1, incluso si hay un camino.
// Requisitos:
// Implementa el siguiente método:
//public static int MinStepHomeWithTimeLimit(bool[,] map, (int, int) home, int T)
//{
    //throw new NotImplementedException();
//}
// Parámetros:
// map: Un array bidimensional de booleanos que indica las posiciones seguras y peligrosas del mapa.
// home: La posición de la casa del Profesor R en el mapa como una tupla 
// (
// 𝑖
// ,
// 𝑗
// )
// (i,j).
// T: El tiempo límite en movimientos para que el Profesor R llegue a su casa.
// Retorno:
// Debe devolver el número mínimo de pasos para que el Profesor R llegue a casa, siempre que llegue antes de agotar el tiempo límite.
// Si no puede llegar en T pasos o no hay un camino posible, devuelve -1.
// Casos de prueba:
// Caso básico sin obstáculos:

// map = [[False, False, False], [False, False, False], [False, False, False]]
// home = (2, 2)
// T = 10
// Salida esperada: 3 (llega en 3 movimientos, dentro del tiempo límite).
// Caso con obstáculos:

// map = [[False, True, False], [False, True, False], [False, False, False]]
// home = (2, 2)
// T = 5
// Salida esperada: -1 (el Profesor no puede llegar a su casa).
// Caso sin tiempo suficiente:

// map = [[False, False, False], [False, False, False], [False, False, False]]
// home = (2, 2)
// T = 2
// Salida esperada: -1 (aunque existe un camino, no puede llegar en 2 movimientos).
// Caso con borde circular:

// map = [[False, False, False], [False, False, False], [False, False, False]]
// home = (2, 0)
// T = 4
// Salida esperada: 3 (usando el borde circular puede llegar más rápido).
// Consejos para la solución:
// Considera usar algoritmos de búsqueda de caminos como BFS (Búsqueda en Anchura) para encontrar el número mínimo de movimientos.
// Implementa una verificación para el límite de tiempo T en cada paso.
// Asegúrate de manejar correctamente el borde circular del mapa.