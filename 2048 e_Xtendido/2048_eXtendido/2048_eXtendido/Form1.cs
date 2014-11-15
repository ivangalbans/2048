using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_2048;
using _2048_eXtendido;

namespace _2048_eXtendido
{
    public partial class frmMain : Form
    {

        //Enumerador de direcciones
        enum Movement{ Right, Left, Down, Up}

        //Crear objeto de la Clase Game
        private Game tablero;

        private bool juegoGanado = false;   //Para controlar si el juego ha sido ganado
        private int level = 0;              //Nivel del juego seleccionado por el jugador
        private int boardSize = 4;          //Tamaño del tablero seleccionado por el jugador
        private int InitialValues = 2;      //Cantidad de valores
        
        public frmMain()
        {
            
            InitializeComponent();

            // Esto en true permite al formulario enterarse cuando se presione una tecla,
            // aun cuando no tenga el foco. De lo contrario, el evento solo llega
            // al control que tiene el foco.
            this.KeyPreview = true;

            //Para que los ComboBox tengan valores al iniciar el formulario
            cboxLevel.SelectedIndex = 0;
            cboxInitialValues.SelectedIndex = 1;

            //Iniciar un nuevo juego
            Restart_Board();

            //Cargar el juego si existe salva
            Load_Game();
        }

        private void pbxBoard_Paint(object sender, PaintEventArgs e)
        {

            //Actualiza los labels  Score, Best y Step
            lblScore.Text = "SCORE: " + (tablero.Score).ToString();
            lblBest.Text = "BEST: " + (tablero.Best).ToString();
            lblStep.Text = "STEP: " + (tablero.Step).ToString();

            //Grosor de las líneas de la grilla
            int grosorLinea = 40 / tablero.Size;
            
            //Ancho de las celdas
            float width = (int) ( (pbxBoard.Width) / tablero.Size);

            //Tamaño ideal de la fuente para los numeros. fuenteSize[i] <-> para un # con i cifras
            float[] fuenteSize = new float[] { 0, 280, 190, 160, 128, 104, 88, 76, 64, 60 };

            #region Pintar Numeros y Colores en celdas
            for (int i = 0; i < tablero.Size; i++)
                for (int j = 0; j < tablero.Size; j++)
                {
                    //Calcula coordenadas en pixeles correspondientes a la posicion de tablero[i,j]
                    //esquina superior izquierda
                    float x = j * (width);
                    float y = i * (width);

                    int Potencia = tablero[i, j].numero;                //número correspondiente en dicha posición
                    int cifrasPotencia = Potencia.ToString().Length;    //Cantidad de cifras del número de la variable Potencia

                    // Tipo de Fuente para pintar el número en PictureBox
                    Font fuentePotencia = new Font("Arial", fuenteSize[cifrasPotencia] / tablero.Size );
                    
                    //Uso de StringFormat para centrar el número en el centro de cada cuadradito
                    StringFormat justification = new StringFormat();
                    justification.Alignment = StringAlignment.Center;        //Alineación Horizontal
                    justification.LineAlignment = StringAlignment.Center;   //Alineación Vertical

                    //Cuadrado que le corresponde en el Picture Box la posicion tablero[i,j]
                    RectangleF cuadro = new RectangleF(x + grosorLinea/2, y+grosorLinea/2, width, width);

                    //Pinta un cuadro negro en las posiciones que hay Obstáculos
                    if (tablero[i, j].obstaculo)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Black), cuadro);
                    
                    //Le asigna a tablero[i,j] el color por defecto del PictureBox si en esa posicion no existe número
                    else if(tablero[i,j].empty)
                        e.Graphics.FillRectangle(new SolidBrush(default(Color)), cuadro);
                    
                    //Pinta el número y el color en el PictureBox, correspondiente a tablero[i,j]
                    else
                    {
                        //Determina el color de la potencia pintar
                        //El por qué de esta fórmula está explicado en el método PotenciaColor la clase Game 
                        int colorPotencia = (int)Math.Log(Potencia, 2) % 11;

                        //Pinta el color que le corresponde en el PictureBox la posicion tablero[i,j]
                        e.Graphics.FillRectangle((tablero[i,j].click == true) ? new SolidBrush(Color.Black) :
                                                   new SolidBrush(tablero[colorPotencia]), cuadro);

                        //Pinta el numero que le corresponde en el PictureBox la posicion tablero[i,j]
                        e.Graphics.DrawString(Potencia.ToString(), fuentePotencia, Brushes.White, cuadro, justification);
                    }
                    
                }
            #endregion
            /*
             * Coordenadas Pixeles es Longitud de la Rejilla
             *                  como
             * Posicion de Array es a la cantidad de casillas       
            */
            #region Dibujar la grilla

            #region Dibujar Lineas interiores
            for (int i = 1; i < tablero.Size; i++)
            {
                //Dibujar Lineas Verticales
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), width*i, 0, grosorLinea, pbxBoard.Width);

                //Dibujar Lineas Horizontales
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0, width * i, pbxBoard.Width, grosorLinea);
            }
            #endregion

            #region Dibujar bordes
            //El error se utiliza para posicionar OK las coordenadas de las lineas Vertical-Derecha
            // y Horizontal-Abajo del Tablero
            int error = 2;

            //Lineas Bordes Verticales
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, grosorLinea, pbxBoard.Width);
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), pbxBoard.Width - grosorLinea - error, 0, grosorLinea, pbxBoard.Width);

            //Lineas Bordes Horizontales
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, pbxBoard.Width, grosorLinea);
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0, pbxBoard.Width - grosorLinea - error, pbxBoard.Width, grosorLinea);
            #endregion

            #endregion

            //Para que el foco (hilo principal de la aplicación) se situe en el PictureBox
            pbxBoard.Focus();

        }

        //Método que se ejecuta cuando se selecciona un nuevo juego
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Restart_Board();
        }

        //Reiniciar el tablero para comenzar un nuevo juego
        private void Restart_Board()
        {
            //Obtiene el Size, el Level y los valores iniciales del juego 
            //introducidos por el usuario
            boardSize = int.Parse(nudSize.Value.ToString());
            level = cboxLevel.SelectedIndex;
            InitialValues = int.Parse(cboxInitialValues.SelectedItem.ToString());

            //Crea una instancia del juego con las nuevas dimensiones
            tablero = new Game(boardSize);

            //Indica que al comenzar la partida el juego no ha sido ganado
            juegoGanado = false;

            //Insertar obstáculos en el tablero, según el nivel seleccionado
            tablero.Insert_Logjam(level);

            //Insertar en el tablero la cantidad de números iniciales elegidos por el jugador
            for (int i = 1; i <= InitialValues; i++)
                tablero.Insert_Numbers();

            // Actualizar el PictureBox
            pbxBoard.Refresh();

        }

        //Método que se ejecuta al dar click en el PictureBox
        private void pbxBoard_MouseClick(object sender, MouseEventArgs e)
        {
            //Determina la columna y fila correspondiente del arreglo según posicion del Mouse (Pixeles x,y)
            int j = e.X * tablero.Size / pbxBoard.Width;    //int j = e.X / (pbxBoard.Width / tablero.Size);
            int i = e.Y * tablero.Size / pbxBoard.Height;   //int i = e.Y / (pbxBoard.Height / tablero.Size);

            //Verificar que se haya dado un click en una casilla que no esté vacía y no sea un obstáculo
            if(tablero[i,j].empty == false && tablero[i,j].obstaculo == false)
            {
                switch (e.Button)
                {
                        //Click Izquierdo
                    case MouseButtons.Left:
                        tablero.set_Stone(i,j,true);        //Marcar el número como una piedra
                        break;

                    //Click Derecho
                    case MouseButtons.Right:
                        tablero.set_Stone(i, j, false);     //Desmarcar en el número la opción piedra
                        break;
                }
            }

            // Actualizar el PictureBox
            pbxBoard.Refresh();
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            tablero.SaveGame(tablero);
        }
        
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            Load_Game();
        }

        private bool Load_Game()
        {
            //Cargar un juego guardado
            bool wasGame = tablero.LoadGame();

            // Actualizar el PictureBox
            pbxBoard.Refresh();

            return wasGame;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            //Para saber si el juego está ganado antes de deshacer la jugada
            if (tablero.youWin())
                juegoGanado = true;

            //Deshacer la jugada
            tablero.UndoGame();

            //Si el juego no fue ganado en la jugada anterior, actualizar la variable juegoGanado
            //Porque puede suceder que usted gane el juego y deshaga la jugada, luego al ganarlo
            //nuevamente el juego debe reconocer que ha ganado ya que la 1era victoria se deshizo
            if (tablero.youWin() == false)
                juegoGanado = false;

            // Actualizar el PictureBox
            pbxBoard.Refresh();
        }

        //Método que se ejecuta al pinchar en ayuda
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp();
            help.Show();
        }

        //Método que se ejecuta al cerrar el juego
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Guardar la partida
            btnSaveGame_Click(sender,e);
        }

        //Método que se ejecuta al pinchar en About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.Show();
        }

        //Método que se ejecuta al presionar una tecla
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            
            #region Directions Arrows
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    tablero.Move((int)Movement.Up);
                    Refresh();
                    break;

                case Keys.Down:
                case Keys.S:
                    tablero.Move((int)Movement.Down);
                    Refresh();
                    break;

                case Keys.Left:
                case Keys.A:
                    tablero.Move((int)Movement.Left);
                    Refresh();
                    break;

                case Keys.Right:
                case Keys.D:
                    tablero.Move((int)Movement.Right);
                    Refresh();
                    break;

            }
            #endregion

            //Verificar que hayas ganado el juego por 1era vez
            if (tablero.youWin() && juegoGanado == false)
            {
                if (MessageBox.Show("You Win, Press Aceptar to Begin or Cancelar to Continue", "Victory 2048", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    Restart_Board();
                juegoGanado = true;
            }

            if (tablero.isGameOver())
                MessageBox.Show("Game Over,Try Again", "Game Over 2048", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}