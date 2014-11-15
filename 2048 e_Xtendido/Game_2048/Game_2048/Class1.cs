using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//Necesario incluir para el trabajo con archivos
using System.IO;

//Necesario incluir para la serialización
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game_2048
{
    //Estructura usada para ir guardando la instancia del juego en cada movimiento
    [Serializable]
    public struct SalvaJuego
    {
        public Casillas[,] tablero;
        public long puntuacion;
        public long mejorPuntuacion;
    }

    //Estructura que posee la configuración de una casilla del tablero
    [Serializable]
    public struct Casillas
    {
        public bool empty;      //True si la casilla esta vacía, False de lo contrario
        public int numero;      //Contiene el número correspondiente a la casilla
        public bool obstaculo;  //True si en la casilla hay obstáculo, False de lo contrario

        //True si el número de la casilla fue seleccionada con un Click Izquierdo,
        //false en caso contrario o si la casilla fue seleccionada con un Click Derecho,
        public bool click;      

        //Sobrecarga del operador ==
        //True si dos casillas que no son vacías ni obstáculos poseen números iguales
        //False en caso contrario
        public static bool operator == ( Casillas first,  Casillas second)
        {
            return (!(first.empty || second.empty) && !(first.obstaculo || second.obstaculo) && (first.numero == second.numero));
        }

        //Sobrecarga del operador ==
        //True si dos casillas no son iguales, False en caso contrario
        public static bool operator !=(Casillas first, Casillas second)
        {
            return !(!(first.empty || second.empty) && !(first.obstaculo || second.obstaculo) && (first.numero == second.numero));
        }
    }


    //Clase del juego que contiene el Constructor, sus Atributos, Propiedades y Métodos 
    [Serializable]
    public class Game
    {
     
        //Atributos
        private int step;                                           //Va almacenando la cantidad de jugadas realizadas
        private long score;                                         //Va almacenando la puntuación obtenida
        private Casillas[,] board;                                  //Contiene la configuración del tablero en el juego
        
        private long best;                                          //Contiene la mejor Puntuación obtenida
        private Color[] colorPotencia = new Color[12];              //Contiene los colores asignados a cada número
        private Stack<SalvaJuego> Undo = new Stack<SalvaJuego>();   //Va almacenando todas las jugadas anteriores

        private bool jugadaValida;  //Para controlar que se haya realizado una jugada válida

        //Constructor de la Clase
        public Game(int size)
        {
            //Inicializar el tablero de dimensiones size x size
            board = new Casillas[size, size];

            score = 0;                  //Inicializar puntuación a cero
            best = Get_BestScore();     //Tomar el record de puntuación hecho anteriormente
            step = 0;                   //Inicializar movimientos a cero
            jugadaValida = true;        //Indicar al comienzo que la jugada es válida

            PotenciaColor();            //Cargar los colores asignados a cada Potencia
            Clear();                    //Crear elementos del tablero por defecto
        }

        //Propiedad Step. Solo para consultar cantidad de movimientos realizados
        public int Step
        {
            get { return step; }
        }

        //Propiedad Size. Solo para consultar el tamaño del tablero
        public int Size
        {
            get { return board.GetLength(0); }
        }

        //Propiedad Best. Solo para consultar la mejor puntuacion
        public long Best
        {
            get { return best; }
        }

        //Propiedad Score. Solo para consultar la puntuacion
        public long Score
        {
            get { return score; }
        }


        //Este indexer permite consultar las Casillas del tablero
        public Casillas this[int row, int column]
        {
            get { return board[row, column]; }
        }

        //Este indexer permite consultar el color del numero de una casilla
        public Color this[int index]
        {
            get { return colorPotencia[index]; }
        }


        #region Métodos Privados
        
        //Realiza una copia de la configuración actual del juego
        private SalvaJuego Copy_CurrentGame()
        {
            SalvaJuego temp;

            temp.puntuacion = Score;                    //Asignar puntuación actual
            temp.mejorPuntuacion = Best;                //Asignar mejor puntuación actual
            temp.tablero = new Casillas[Size, Size];    //Crear instancia a temp.tablero con las dimensiones del actual tablero
            CopyBoard(board, temp.tablero);             //Copiar el tablero actual en la salva

            return temp;                                //Retornar la salva temporal del juego
        }


        //Asignar un color a cada número: color[i] <-> color de los números:
        //      2 ^ (i+11*k)  para k = 0,1,2,... ;  (i+11*k) != 0
        private void PotenciaColor()
        {
            //Colores de los números en RGB
            colorPotencia[0] = Color.FromArgb(0, 0, 0);
            colorPotencia[1] = Color.FromArgb(180, 190, 255);
            colorPotencia[2] = Color.FromArgb(100, 200, 200);
            colorPotencia[3] = Color.FromArgb(100, 177, 121);
            colorPotencia[4] = Color.FromArgb(245, 149, 99);
            colorPotencia[5] = Color.FromArgb(246, 124, 95);
            colorPotencia[6] = Color.FromArgb(246, 94, 59);
            colorPotencia[7] = Color.FromArgb(237, 207, 114);
            colorPotencia[8] = Color.FromArgb(237, 204, 97);
            colorPotencia[9] = Color.FromArgb(237, 200, 80);
            colorPotencia[10] = Color.FromArgb(237, 197, 63);
        }

        //Crea un tablero con valores en las casillas por defecto
        private void Clear()
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = DefaultCasillas();
        }

        //Determina si existe al menos una celda vacía
        private bool There_is_EmptyCell()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (board[i, j].empty)
                        return true;
            return false;
        }

        //Determina si una celda es igual a su adyacente de la derecha o abajo
        private bool Check_Pair(int row, int column)
        {
            //Verificar que exista una columna a la derecha de la posición actual
            if (Size - column != 1)
            {
            //Verdadero si la casilla actual es igual y su adyacente de la derecha
                if ((board[row, column] == board[row, column + 1]))
                    return true;
            }

            //Verificar que exista una fila debajo de la posición actual
            if (Size - row != 1)
            {
                 //Verdadero si la casilla actual es igual a su adyacente de abajo
                if (board[row, column] == board[row + 1, column])
                    return true;
            }

            return false;
        }

        //Determina si existen al menos dos pares de números iguales en todo el tablero
        private bool Equals_Numbers_Adjacent()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (Check_Pair(i, j))
                        return true;
            return false;
        }

        //Método que mezcla y desplaza casillas del tablero según las reglas del juego
        private bool Merge_and_Displace_Right_or_Left(int direccion)
        {
            //Indica si hubo algun movimiento de Casillas
            bool hubo_jugada = false;

            //0 Derecha
            //1 Izquierda

            //Contiene el índice donde comienza el puntero y su correspondiente incremento para 
            //los movimientos DERECHA e IZQUIERDA
            int[,] vectorPointer = { { Size - 1, -1 }, { 0, 1 } };

            //Contiene el inicio, la condición y el incremento de los movimientos DERECHA e IZQUIERDA
            int[,] vectorDirection = { {Size-2, -1, -1, },
                                            {1, Size, 1}
                                        };
            
            int pointer_change = vectorPointer[direccion, 1];   //Comportamiento del cambio del puntero

            //Comportamiento de las columnas: comienzo, parada, cambio
            int column_begin = vectorDirection[direccion, 0];       
            int column_end = vectorDirection[direccion, 1];         
            int column_change = vectorDirection[direccion, 2];   

            //Ir recorriendo el tablero para cada una de las columnas
            for (int i = 0; i < Size; i++)
            {
                //Puntero que se sirve como pivote para ir buscando en dependencia de la dirección por toda
                //la columna los números e ir mezclando o moviendo estos, según la lógica del algoritmo
                int pointer = vectorPointer[direccion, 0];
                
                for (int j = column_begin; j != column_end; j+=column_change)
                {

                    if (board[i, j].obstaculo == true)
                       pointer = j;                      

                    //Si las dos Casillas son iguales y ninguna es una piedra (no se le ha dado click)
                    else if (board[i, pointer] == board[i, j] && !(board[i, pointer].click || board[i, j].click))
                    {
                        board[i, pointer].numero <<= 1;       

                        board[i, j] = DefaultCasillas();

                        score += board[i, pointer].numero;    //Actualizar la puntación al mezclar dos casillas

                        //Actualizar el Record de Puntuación si este fue sobrepasado
                        if (score > best)
                        {
                            best = score;
                            Set_BestScore();
                        }
                        
                        //Cambiar el puntero
                        pointer += pointer_change;

                        hubo_jugada = true;

                    }
                    
                    //Verificar si estoy analizando una casilla no vacía
                    else if (board[i, j].empty == false)
                    {
                        //Si la casilla a la que apunta puntero es vacía
                        if(board[i,pointer].empty == true)
                        {
                            //Intercambiar posición de board[i, j] con board[i, pointer]
                            board[i, pointer] = board[i, j];
                            board[i, j] = DefaultCasillas();
                            hubo_jugada = true;
                        }
                        //Si en la casilla a la que apunta puntero no está vacía y existen casillas
                        //vacías por el medio, mover la casilla  board[i, j] hasta la casilla adyacente 
                        //(dependiendo de la dirección) a la que apunta puntero
                        else if( Math.Abs(pointer - j) >= 2)
                        {
                            board[i, pointer+pointer_change] = board[i, j];
                            board[i, j] = DefaultCasillas();

                            hubo_jugada = true;
                            pointer += pointer_change;
                        }
                        //Cambiar el puntero
                        else
                            pointer += pointer_change;
                    }

                }

            }

            return hubo_jugada;
        }

        //Obtiene de un archivo la mejor puntuación
        private static int Get_BestScore()
        {
            //Le asigna a fileName el nombre del archivo que contiene la mejor puntuación
            string fileName = "2048_eXtendido.exe.save.bestScore.bkf";

            //La clase FileStream se crea para el trabajo con archivos
            //Se instancia pasando el nombre de archivo, el modo y acceso como parámetros
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);

            //Se crea para leer la puntuación del archivo con nombre filestream
            StreamReader scoreReader = new StreamReader(fileStream);

            //Lee contenido del archivo que contiene la mejor puntuación
            string bestScore = scoreReader.ReadLine();

            //Cerrar el flujo
            scoreReader.Close();

            //Devuelve cero en caso de que en el archivo no se encuentre el record de puntuación
            //Devuelve la puntuación en caso contrario
            return (bestScore == null) ? 0 : int.Parse(bestScore);
        }

        //Guarda la mejor puntuación hacia un archivo
        private void Set_BestScore()
        {
            //Le asigna a fileName el nombre del archivo al que se va a guardar la mejor puntuación
            string fileName = "2048_eXtendido.exe.save.bestScore.bkf";

            //La clase FileStream se crea para el trabajo con archivos
            //Se instancia pasando el nombre de archivo, el modo y acceso como parámetros
            FileStream filStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            //Se crea para escribir la puntuación hacia el fichero con nombre filestream
            StreamWriter scoreWriter = new StreamWriter(filStream);

            //Escribe hacia el archivo la mejor puntuación
            scoreWriter.WriteLine(best);

            //Cerrar el flujo
            scoreWriter.Close();
        }

        //Devuelve el formato de una casilla por defecto
        private Casillas DefaultCasillas()
        {
            Casillas temp;
            temp.empty = true;
            temp.obstaculo = false;     
            temp.numero = 0;            
            temp.click = false;

            return temp;
        }

        //Para hallar la traspuesta de board
        private void Transpose_Board()
        {
            Casillas[,] tableroTemporal = new Casillas[board.GetLength(0), board.GetLength(1)];

            //Hacer copia del board para no perder los elementos originales de board en las asignaciones
            CopyBoard(board, tableroTemporal);

            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(0); j++)
                    board[j, i] = tableroTemporal[i, j];
        }

        //Método que copia un Array Bidimensional de tipo Casillas hacia otro
        private void CopyBoard(Casillas[,] source, Casillas[,] destination)
        {
            for (int i = 0; i < source.GetLength(0); i++)
                for (int j = 0; j < source.GetLength(1); j++)
                    destination[i, j] = source[i, j];
        }

        //Quitar todas las piedras del Tablero
        private void Remove_Stone()
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j].click = false;
        }

        //Método que contiene la Lógica realizada para un movimiento en cualquier dirección
        private void Movement_Logic(int direccion)
        {
            //Si el movimiento es ARRIBA o ABAJO
            if(direccion == 2 || direccion == 3)
            {
                //Mover hacia la ABAJO es lo mismo que ejecutarle el método DERECHA a la traspuesta del tablero
                //y luego ejecutar la traspuesta de nuevo para regresar al tablero original
                //(Sucede lo mismo para mover hacia ARRIBA con el método IZQUIERDA)
                Transpose_Board();
                jugadaValida = Merge_and_Displace_Right_or_Left( direccion - 2 );
                Transpose_Board();
            }
            else
                jugadaValida = Merge_and_Displace_Right_or_Left(direccion);

            if(jugadaValida)
            {
                Remove_Stone();
                step++;         //Incrementar movimientos
            }
            Insert_Numbers();
        }

        #endregion


        //***********************************************************************************************************************
        #region Metodos Publicos


        //Método que permite ver la jugada anterior
        public void UndoGame()
        {
            //Controlar que exista una jugada anterior
            if (Undo.Count != 0)
            {
                score = Undo.Peek().puntuacion;           //Guarda la puntuación anterior
                best = Undo.Peek().mejorPuntuacion;       //Guarda la mejor puntuación anterior
                CopyBoard((Undo.Pop()).tablero, board);   //Copiar la configuración del tablero de la jugada anterior
                step--;                                   //Decrementar movimientos
            }
        }

        #region Save & Load Game with Serialization
        //Método que guarda el juego hacia un fichero 
        public void SaveGame(Game serOut)
        {
            //Le asigna a fileName el nombre del archivo que contendrá la salva del juego
            string fileName = "2048_eXtendido.exe.save.game.igs";

            //La clase FileStream se crea para el trabajo con archivos
            //Este objeto es de solo escritura y abre un archivo o lo crea si este no existe de nombre fileName
            FileStream outStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            //Se crea un formateador de realización para determinar como debe
            //ser serializado el objeto
            BinaryFormatter binWriter = new BinaryFormatter();

            //Se invoca el método Serialize del BinaryFormatter con dos argumentos,
            //el flujo y el objeto a serializar
            binWriter.Serialize(outStream, serOut);

            //Se cierra el flujo
            outStream.Close();
        }

        //Método que carga el juego de un fichero
        public bool LoadGame()
        {
            //Le asigna a fileName el nombre del archivo que contendría la salva del juego
            //si este existiera
            string fileName = "2048_eXtendido.exe.save.game.igs";

            //Se crea un objeto de la Clase FileInfo, pasándole como parámetro el nombre del archivo
            //sobre el cual queremos trabajar. Esta clase posee un conjunto de propiedades y métodos de
            //instancia necesarios para el trabajo con archivos
            FileInfo infoSaveGame = new FileInfo(fileName);

            //Verificar que el archivo exista para que este pueda cargar el juego.
            //En caso contrario, no existe ninguna partida guardada del juego
            if(infoSaveGame.Exists)
            {
                //La clase FileStream se crea para el trabajo con archivos
                //Este objeto es de solo lectura y abre un archivo de nombre fileName
                FileStream inStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                //Crear un objeto de la Clase Game
                Game serIn = new Game(Size);

                //Se crea un formateador de realización para determinar como debe
                //ser serializado el objeto
                BinaryFormatter binReader = new BinaryFormatter();

                //Se invoca el método Deserialize del BinaryFormatter con el flujo como argumento
                //Este método devuelve un objeto de la clase especificada entre paréntesis
                serIn = (Game)binReader.Deserialize(inStream);

                //Actualizar cada atributo con los datos deserializados de FileName

                board = new Casillas[serIn.Size, serIn.Size];
                
                CopyBoard(serIn.board, board);
                
                score = serIn.score;
                best = serIn.best;
                step = serIn.step;
                Undo = serIn.Undo;
                
                //Cerrar el flujo
                inStream.Close();
                
                //Para indicar que el juego ha sido cargado
                return true;
            }
            //Indica que no existe ninguna salva del juego
            return false;
        }
        #endregion

        #region Insertar obstáculos y números

        //Inserta obstáculos en el tablero dependiendo del nivel seleccionado y el tamaño del tablero
        public void Insert_Logjam(int Level)
        {
            int cantObstaculos = 0;

            #region Cantidad de Obstáculos según nivel
            switch (Level)
            {
                case 1:
                    cantObstaculos = (int)Size / 4;
                    break;

                case 2:
                    cantObstaculos = (int) (Size) / 2;
                    break;

                case 3:
                    cantObstaculos = Size;
                    break;
            }
            #endregion

            #region Para insertar n obtáculos
            for (int i = 1; i <= cantObstaculos; i++)
            {
                Random rnd = new Random();
                int row = 0, column = 0;

                do
                {
                    row = rnd.Next(0, board.GetLength(0));      //Genera una fila aleatoria
                    column = rnd.Next(0, board.GetLength(0));   //Genera una columna aletoria
                }
                //El ciclo finaliza cuando la posición generada esté vacía
                while (board[row, column].empty == false);

                board[row, column].empty = false;       //Indica que esta posición no está vacía
                board[row, column].obstaculo = true;    //Pone un obstáculo en esta posición
            }
            #endregion
        }

        //Método que inserta un número en posición aleatoria en el tablero si la jugada fue válida
        public void Insert_Numbers()
        {
            //Inserta un número si la jugada fue válida
            if (jugadaValida)
            {
                //Array usado para controlar que se insertarán 90% de 2, y un 10% de 4 
                int[] NumerosGenerar = { 2, 2, 2, 2, 4, 2, 2, 2, 2, 2 };
                
                Random rnd = new Random();
                int row = 0, column = 0;

                do
                {
                    row = rnd.Next(0, board.GetLength(0));     //Genera una fila aleatoria
                    column = rnd.Next(0, board.GetLength(0));  //Genera una columna aletoria
                }
                //El ciclo finaliza cuando la posición generada esté vacía
                while (board[row, column].empty == false);

                //Asignar en la posición generada un número aleatorio
                board[row, column].numero = NumerosGenerar[rnd.Next(0, 10)];

                //Indica que esta posición ya no está vacía
                board[row, column].empty = false;
            }
        }
        #endregion
        //Método que realiza los movimientos Arriba(3)-Abajo(2)-Izquierda(1)-Derecha(0)
        //Recibe la dirección del movimiento dada por un entero
        public void Move(int posDirection)
        {

            //Guardar el instante actual de la partida
            SalvaJuego currentGame = Copy_CurrentGame();
            
            Movement_Logic(posDirection);
            
            //Para asignar en la pila las jugadas anteriores si hubo jugada válida
            if (jugadaValida)
                Undo.Push(currentGame);
        }
        
        //Método que determina si el jugador ha perdido
        public bool isGameOver()
        {
            //Verdadero si no existen celdas vacías ni números adyacentes iguales
            return !(There_is_EmptyCell() || Equals_Numbers_Adjacent());
        }

        //Método que determina si el jugador ha ganado
        public bool youWin()
        {
            //Verifica si el jugador logró formar el número 2048
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (board[i, j].numero == 2048)
                        return true;
            return false;
        }

        //Marca o desmarca la celda con coordenadas (row,column) como piedra
        public void set_Stone(int row, int column, bool isStone)
        {
            board[row,column].click = isStone;
        }

        #endregion


    }
}
