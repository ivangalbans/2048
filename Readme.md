Juego 2048
================================================

Resumen
-------

El 2048 es un juego que consiste en un tablero de 4x4 casillas en el que se ubican piezas con números. Los
números siempre son una potencia de dos mayor o igual que dos. En cada turno el usuario debe decidir una
dirección en la que mover todas las piezas del tablero (arriba, abajo, derecha o izquierda). Si en la dirección en que se mueven las piezas existen dos piezas de igual valor consecutivas, estas se combinan para formar una única pieza con valor igual a la suma de las dos mezcladas.
Note que las piezas se mueven hasta que llegan a la última casilla posible o chocan con una pieza que ya no se puede mover más. En un único movimiento una pieza sólo se mezcla una vez y si existen varias posibilidades se mezcla solamente la de la pieza más avanzada en la dirección seleccionada.

Al principio el juego empieza con sólo dos piezas en posiciones aleatorias y que pueden ser de valor 2 ó 4. Después de cada movimiento válido aparece en una casilla aleatoria un 2 ó un 4. Un movimiento es válido si con él se puede mover (o mezclar) alguna pieza. Si no existen movimientos posibles en un tablero el juego termina. En cada jugada se acumula en una puntuación del jugador el valor de las piezas que fueron mezcladas (por ejemplo, si se mezclan dos 4s se acumularía un 8). Si se alcanza una casilla con valor 2048 se dice que el jugador ganó (aunque puede continuar acumulando puntos).
El jugador tiene un conjunto de posibilidades de deshacer la última jugada (ambos, el movimiento y la aparición de la nueva pieza). En el juego original solo se puede realizar esta operación en dos ocasiones durante la partida.

Extensiones
-----------

Usted deberá desarrollar una aplicación visual de Windows (ya sea Windows Forms o Windows Presentation
Foundation) que permita a un usuario jugar 2048 extendido. Este juego será la misma lógica del original pero con algunos cambios:

1. El tamaño del tablero puede ser especificado antes de comenzar la partida y podrá ser desde 4x4 hasta 16x16 (siempre cuadrado). La cantidad de valores iniciales puede ser también variable desde 1 hasta 3.

2. La cantidad de veces que se puede deshacer la jugada no tiene límites (tenga en cuenta que cada vez que se deshace una jugada, además de restaurar el tablero se quita los puntos ganados en la jugada deshecha).

3. El jugador puede salvar un juego para continuarlo más adelante.

Autor
------

Iván Galbán Smith <ivan.galban.smith@gmail.com>

Estudiante de 1er Curso de Ciencia de la Computación

Universidad de La Habana, 2014