using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2048_eXtendido
{


    public partial class frmHelp : Form
    {
        //Para almacenar textos de la ayuda
        private string[] TextHelp = new string[6];
        
        //Para controlar que texto mostrar
        private int index = 0;

        public frmHelp()
        {
            InitializeComponent();
            Load_Help();
        }

        //Cargar contenido de la ayuda: Textos, Imágenes
        private void Load_Help()
        {
            LoadHelp();
            pbxFotosHelp.ImageLocation = "fotosHelp/0.png";
            lblTextHelp.Text = TextHelp[index];
            Refresh();
        }


        //Metodo que asigna los textos de la ayuda al string TextHelp para luego mostrar en Label
        private void LoadHelp()
        {
            #region 1er Texto
            TextHelp[0] = "El 2048 es un juego que consiste en un tablero de 4x4 casillas en el que se ubican\n"+
                          "piezas con números. Los números siempre son una potencia de dos mayor o igual que\n"+
                          "dos. En cada turno el usuario debe decidir una dirección en la que mover todas las\n"+
                          "piezas del tablero (arriba, abajo, derecha o izquierda). Si en la dirección en que\n"+
                          "se mueven las piezas existen dos piezas de igual valor consecutivas, estas se com-\n"+
                          "binan para formar una única pieza con valor igual a la suma de las dos mezcladas.\n"+
                          "La siguiente figura muestra un tablero y el resultado de haber “movido” las piezas\n"+
                          "hacia la derecha.";
            #endregion
            #region 2do Text0
            TextHelp[1] = "Note que las piezas se mueven hasta que llegan a la última casilla posible o\n" +
                          "chocan con una  pieza que ya no se puede mover más.  En un único movimiento\n" +
                          "una pieza sólo se mezcla una vez y si existen varias posibilidades se mezcla\n" +
                          "solamente la de la pieza más avanzada en la dirección seleccionada. Las figuras\n" +
                          "a continuación representan estos escenarios.\n" +
                          "4 casillas iguales consecutivas, se mezclan únicamente 2 pares.";
            #endregion
            #region 3er Texto
            TextHelp[2] = "Aunque quedan dos 4 luego de mezclar los 2s estos no se mezclan en el mismo\n" +
                          "movimiento. 3 casillas iguales consecutivas, se mezcla únicamente el par más\n" +
                          "avanzado en la dirección. En el movimiento se podrían mezclar el 2 más a la\n" +
                          "izquierda con el 2do, sin embargo se debe mezclar el más a la derecha con el\n" +
                          "anterior.";
            #endregion
            #region 4to Texto
            TextHelp[3] = "Al principio el juego empieza desde una hasta tres piezas en posiciones aleatorias y\n"+
                          "que pueden ser de valor 2 ó 4. Después de cada movimiento válido aparece en una casilla\n"+
                          "aleatoria un 2 ó un 4. Un movimiento es válido si con él se puede mover (o mezclar) alguna\n"+
                          "pieza. Si no existen movimientos posibles en un tablero el juego termina. En cada jugada\n"+
                          "se acumula en una puntuación del  jugador el valor de las piezas que fueron mezcladas\n"+
                          "(por ejemplo, si se mezclan dos 4s se acumularía un 8).  Si se alcanza  una  casilla con\n"+
                          "valor 2048 se dice que el jugador ganó. El jugador tiene un conjunto de posibilidades\n"+
                          "de deshacer la última jugada (ambos, el movimiento y la aparición de la nueva pieza)\n"+
                          "ilimitadamente.";
            #endregion
            #region 5to Texto
            TextHelp[4] = "Antes de comenzar a jugar 1ero usted debera especificar el tamaño del tablero que desea,\n" +
                          "luego escoger el nivel de dificultad si lo desea y dar un click en el botón New Game (F1).\n" +
                          "Para guardar la partida, solo de click en Save Game (Ctrl-S) o cerrando el juego su parti-\n" +
                          "da será guardada automáticamente.\n" +
                          "Para comenzar una partida guardada deber deberá dar click en el botón Load Game (Ctrl-O).\n" +
                          "Además este juego a través del botón Undo (Ctrl-Z) le permite Deshacer sus jugadas ilimita-\n" +
                          "damente, o sea, hasta la partida inicial.\n" +
                          "También, a la derecha superior de la ventana se puede visualizar en Best la mejor\n" +
                          "puntuación hasta el momento alcanzada en el juego 2048_eXtendido y Step, muestra\n" +
                          "la cantidad de jugadas que ha realizado el jugador.";
            #endregion
            #region 6to Texto
            TextHelp[5] = "		Extensiones del juego\n"+
                          "1) Cuando el jugador elige niveles de dificultad (Level), en el tablero aparecen obstáculos\n"+
                          "de color negro en posiciones aleatorias y una cantidad directamente proporcional al tamaño\n"+
                          "del tablero especificado (Size). La imagen de la izquierda es un ejemplo de un tablero\n"+
                          "de 6x6 con 6 obtáculos. Sus funciones en el tablero son de impedir el movimiento de los nú-\n"+
                          "meros y se garantiza que nunca aparecerá un número sobre un obstáculo.\n"+
                          "2) Al dar click izquierdo sobre un número, este cambia su color a negro (imagen de la iz-\n"+
                          "quierda), esto indica que dicho número durante una jugada será una piedra.\n"+
                          "La función de la piedra es moverse igual que los números, pero esta no se mezcla con ellos.\n"+
                          "En la imagen de la derecha la piedra es el 2 al que apunta la flecha negra, y al jugar hacia\n"+
                          "abajo (flecha azul) los números que serán mezclados son los 2s señalados por la flecha roja.\n"+
                          "Para desmarcar la piedra de click derecho sobre ella.";
            #endregion
        }

        //Método que se ejecuta al dar click en el botón Next
        private void btnNext_Click(object sender, EventArgs e)
        {
            //Verificar que no esté en la última página
            if(index != 5)
            {
                //Asignar texto siguiente
                lblTextHelp.Text = TextHelp[++index];

                //Cargar imagen siguiente
                pbxFotosHelp.ImageLocation = "fotosHelp/" + index.ToString() + ".png";

                Refresh();
            }
        }

        //Método que se ejecuta al dar click en el botón Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            //Verificar que no esté en la 1era página
            if (index != 0)
            {
                //Asignar texto anterior
                lblTextHelp.Text = TextHelp[--index];

                //Cargar imagen anterior
                pbxFotosHelp.ImageLocation = "fotosHelp/" + index.ToString() + ".png";

                Refresh();
            }
        }

    }
}
