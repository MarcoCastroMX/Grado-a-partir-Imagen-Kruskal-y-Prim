using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Actividad_4
{
    public partial class MainForm : Form
    {
        private string imagen;
        Bitmap Picture, Grafo, ARM,copia;
        bool ArmPrim = false, ArmKruskal = false;
        int ContVertices;
        const int k = 3;
        Color Negro = Color.FromArgb(255, 0, 0, 0);
        Color Rojo = Color.FromArgb(255, 255, 0, 0);
        Color Blanco = Color.FromArgb(255, 255, 255, 255);
        Color Azul = Color.FromArgb(255, 0, 0, 255);
        Font drawFont = new Font("Arial", 10);
        Color colorpixel;
        Point p_0, p_f;
        Grafo G, ArbolPrim, ArbolKruskal;
        Vertice Vaux;
        string[] cadenas;
        List<Point> Resultado;
        List<Vertice> CaminoPrim,CaminoKruskal;
        Brush drawBrush, BrochaAgente, BrochaNumero;
        List<Arista> AristasKruskal = new List<Arista>();

        public MainForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            p_0 = new Point();
            p_f = new Point();
            Resultado = new List<Point>();
            BrochaNumero = new SolidBrush(Color.OrangeRed);
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void BtnCargarImagenClick(object sender, EventArgs e) {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    imagen = openFileDialog1.FileName;
                    Picture = new Bitmap(imagen);
                    Grafo = new Bitmap(imagen);
                    pictureBox1.Image = Picture;
                    labelMenor.Text = "";
                    this.btnGrafo.Enabled = true;
                    this.BtnAgentePrim.Enabled = false;
                    this.comboBox1.Enabled = false;
                    this.BtnARMporPrim.Enabled = false;
                    this.BtnARMporKruskal.Enabled = false;
                    this.comboBox1.Text = "";
                    this.BtnAgenteKruskal.Enabled = false;
                    G = new Grafo();
                    listBox1.Items.Clear();
                    TamAristasPrim.Items.Clear();
                    TamAristasKruskal.Items.Clear();
                    ContVertices = 1;
                    comboBox1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        Vertice EncontrarCentro(int x, int y) {
            int x_i, x_f, x_act, x_c;
            int y_i, y_f, y_act, y_c;
            y_act = y;
            y_i = y;
            do {
                colorpixel = Picture.GetPixel(x, ++y_act);
            } while (colorpixel == Negro || colorpixel == Rojo);
            y_f = y_act - 1;
            y_act = y;
            do {
                colorpixel = Picture.GetPixel(x, --y_act);
            } while (colorpixel == Negro || colorpixel == Rojo);
            y_i = y_act + 1;
            y_c = (y_i + y_f) / 2;
            x_act = x;
            do {
                colorpixel = Picture.GetPixel(--x_act, y_c);
            } while (colorpixel == Negro || colorpixel == Rojo);
            x_i = x_act + 1;
            x_act = x;
            do {
                colorpixel = Picture.GetPixel(++x_act, y_c);
            } while (colorpixel == Negro || colorpixel == Rojo);
            x_f = x_act - 1;
            x_c = (x_f + x_i) / 2;
            int r = (x_f - x_c);
            Vertice vertice = new Vertice(x_c, y_c, r, ContVertices++);
            return vertice;
        }

        void DibujarCentro(int x, int y) {
            for (int i = -k; i <= k; i++) {
                for (int j = -k; j <= k; j++) {
                    Grafo.SetPixel(x + i, y + j, Rojo);
                    pictureBox1.Image = Grafo;
                }
            }
        }

        void DibujarCirculo(Point punto, Brush brocha, Bitmap bmp) {
            int r = 16;
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.FillEllipse(brocha, punto.X - r, punto.Y - r, r * 2, r * 2);
        }

        void DibujarId(Point punto, Brush Brocha, Bitmap bmp, int numero) {
            Graphics graphics = Graphics.FromImage(bmp);
            string cadena = numero.ToString();
            graphics.DrawString(cadena, drawFont, Brocha, punto);
        }

        void BtnCerrarClick(object sender, EventArgs e) {
            Application.ExitThread();
        }

        void BtnGrafoClick(object sender, EventArgs e) {
            int x, y;
            List<Vertice> lv = G.getLv();
            Rectangle Dimensiones = new Rectangle(0, 0, Picture.Width, Picture.Height);
            System.Drawing.Imaging.PixelFormat formato = Picture.PixelFormat;
            Grafo = Picture.Clone(Dimensiones, formato);
            this.comboBox1.Items.Clear();
            this.BtnAgentePrim.Enabled = false;
            this.comboBox1.Enabled = false;
            for (y = 0; y < Picture.Height; y += 20) {
                for (x = 0; x < Picture.Width; x += 20) {
                    colorpixel = Picture.GetPixel(x, y);
                    if (colorpixel == Negro) {
                        Vaux = EncontrarCentro(x, y);
                        if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() && l.getY() == Vaux.getY()))) {
                            ContVertices--;
                        }
                        else {
                            if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() && l.getY() == Vaux.getY() + 1))) {
                                ContVertices--;
                            }
                            else {
                                if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() + 1 && l.getY() == Vaux.getY()))) {
                                    ContVertices--;
                                }
                                else {
                                    if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() && l.getY() == Vaux.getY() - 1))) {
                                        ContVertices--;
                                    }
                                    else {
                                        if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() - 1 && l.getY() == Vaux.getY()))) {
                                            ContVertices--;
                                        }
                                        else {
                                            if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() + 1 && l.getY() == Vaux.getY() + 1))) {
                                                ContVertices--;
                                            }
                                            else {
                                                if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() - 1 && l.getY() == Vaux.getY() - 1))) {
                                                    ContVertices--;
                                                }
                                                else {
                                                    if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() + 1 && l.getY() == Vaux.getY() - 1))) {
                                                        ContVertices--;
                                                    }
                                                    else {
                                                        if (lv.Contains(lv.Find(l => l.getX() == Vaux.getX() - 1 && l.getY() == Vaux.getY() + 1))) {
                                                            ContVertices--;
                                                        }
                                                        else {
                                                            lv.Add(Vaux);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            cadenas = new string[lv.Count];
            for (int i = 0; i < lv.Count; i++) {
                cadenas[i] = lv[i].getId().ToString();
            }
            Graphics graphics = Graphics.FromImage(Grafo);
            drawBrush = new SolidBrush(Color.GhostWhite);
            for (int i = 0; i < lv.Count; i++) {
                for (int j = 0; j < lv.Count; j++) {
                    p_0.X = lv[i].getX();
                    p_0.Y = lv[i].getY();
                    p_f.X = lv[j].getX();
                    p_f.Y = lv[j].getY();
                    if (lv[i].getId().ToString() == lv[j].getId().ToString()) {

                    }
                    else {
                        List<Point> Resultado = DDA();
                        if (Resultado != null) {
                            pictureBox1.Refresh();
                            double distancia = Math.Sqrt(Math.Pow((double)p_f.X - (double)p_0.X, 2) + Math.Pow((double)p_f.Y - (double)p_0.Y, 2));
                            lv[i].addArista(lv[j], distancia, lv[i], Resultado);
                        }
                    }
                }
            }
            for (int i = 0; i < lv.Count; i++) {
                List<Arista> la = lv[i].getLa();
                DibujarCentro(lv[i].getX(), lv[i].getY());
                graphics.DrawString(cadenas[i], drawFont, drawBrush, lv[i].getX(), lv[i].getY());
            }
            for (int i = 1; i <= lv.Count; i++) {
                comboBox1.Items.Add(i);
            }
            this.comboBox1.Enabled = true;
            foreach (Vertice v in lv)
            {
                if (v.getLa().Count != 0)
                    this.BtnARMporKruskal.Enabled = true;
            }
            pictureBox1.BackgroundImage = Grafo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            Rectangle Rectangulo = new Rectangle(0, 0, Grafo.Width, Grafo.Height);
            System.Drawing.Imaging.PixelFormat Format = Grafo.PixelFormat;
            ARM = Grafo.Clone(Rectangulo, Format);
        }

        public void Longitudes()
        {
            Graphics graphics = Graphics.FromImage(Grafo);
            List<Vertice> lv = G.getLv();
            List<Vertice> Visitados = new List<Vertice>();
            foreach (Vertice v in lv)
            {
                List<Arista> la = v.getLa();
                Visitados.Add(v);
                foreach (Arista a in la)
                {
                    if (!Visitados.Contains(a.getVertex()))
                    {
                        Point Medio;
                        Medio = new Point();
                        int Total = a.getLinea().Count;
                        Medio = a.getLinea()[Total / 2];
                        Double Ponderacion = Math.Round(a.getPond());
                        graphics.DrawString(Ponderacion.ToString(), drawFont, BrochaNumero, Medio);
                    }
                }
            }
        }

        List<Point> DDA() {
            double m = ((double)p_f.Y - (double)p_0.Y) / ((double)p_f.X - (double)p_0.X);
            double b = (double)p_0.Y - (double)m * (double)p_0.X;
            double y_i, x_i;
            bool band = false;
            bool band2 = false;
            int inc = 1;
            Point Coordenadas;
            List<Point> Linea = new List<Point>();
            Coordenadas = new Point();
            if (Double.IsInfinity(m)) {
                if (p_0.Y > p_f.Y)
                    inc = -1;
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc) {
                    x_i = p_0.X;
                    colorpixel = Picture.GetPixel((int)Math.Round(x_i), (int)y_i);
                    if (colorpixel == Blanco) {
                        band = true;
                    }
                    if (colorpixel != Blanco && band == true) {
                        band2 = true;
                    }
                    if (colorpixel == Blanco && band2 == true) {
                        return null;
                    }
                }
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc) {
                    x_i = p_0.X;
                    Coordenadas.X = (int)x_i;
                    Coordenadas.Y = (int)y_i;
                    Linea.Add(Coordenadas);
                    Grafo.SetPixel(Coordenadas.X, Coordenadas.Y, Color.Black);
                }
                return Linea;
            }
            if (m <= 1 && m >= -1) {
                if (p_0.X > p_f.X)
                    inc = -1;
                for (x_i = p_0.X; (int)x_i != p_f.X; x_i += inc) {
                    y_i = m * x_i + b;
                    colorpixel = Picture.GetPixel((int)x_i, (int)Math.Round(y_i));
                    if (colorpixel == Blanco) {
                        band = true;
                    }
                    if (colorpixel != Blanco && band == true) {
                        band2 = true;
                    }
                    if (colorpixel == Blanco && band2 == true) {
                        return null;
                    }
                }
                for (x_i = p_0.X; (int)x_i != p_f.X; x_i += inc) {
                    y_i = m * x_i + b;
                    Coordenadas.X = (int)x_i;
                    Coordenadas.Y = (int)Math.Round(y_i);
                    Linea.Add(Coordenadas);
                    Grafo.SetPixel(Coordenadas.X, Coordenadas.Y, Color.Black);
                }
                return Linea;
            }
            else {
                if (p_0.Y > p_f.Y)
                    inc = -1;
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc) {
                    x_i = (y_i - b) / m;
                    colorpixel = Picture.GetPixel((int)Math.Round(x_i), (int)y_i);
                    if (colorpixel == Blanco) {
                        band = true;
                    }
                    if (colorpixel != Blanco && band == true) {
                        band2 = true;
                    }
                    if (colorpixel == Blanco && band2 == true) {
                        return null;
                    }
                }
                for (y_i = p_0.Y; (int)y_i != p_f.Y; y_i += inc) {
                    x_i = (y_i - b) / m;
                    Coordenadas.X = (int)Math.Round(x_i);
                    Coordenadas.Y = (int)y_i;
                    Linea.Add(Coordenadas);
                    Grafo.SetPixel(Coordenadas.X, Coordenadas.Y, Color.Black);
                }
                return Linea;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (Vertice v in G.getLv())
            {
                if (v.getLa().Count != 0)
                {
                    this.BtnARMporPrim.Enabled = true;
                    break;
                }
            }
        }

        private void BtnAgentePrim_Click(object sender, EventArgs e)
        {
            ArmPrim = true;
            ArmKruskal = false;
            pictureBox1.BackgroundImage = ARM;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            List<Vertice> Visitados = new List<Vertice>();
            Stack<Vertice> Pila = new Stack<Vertice>();
            CaminoPrim = new List<Vertice>();
            int Buscado = comboBox1.SelectedIndex + 1;
            foreach (Vertice v in ArbolPrim.getLv())
            {
                if (Buscado == v.getId())
                {
                    Pila.Push(v);
                    Visitados.Add(v);
                    CaminoPrim.Add(v);
                    break;
                }
            }
            DFS(Pila, Visitados, CaminoPrim);
            while(Visitados.Count != ArbolPrim.getLv().Count)
            { 
                foreach (Vertice v in ArbolPrim.getLv())
                {
                    bool Band = false;
                    foreach (Vertice Bus in Visitados)
                    {
                        if (v.getId() == Bus.getId())
                        {
                            Band = true;
                            break;
                        }
                    }
                    if (Band == false)
                    {
                        Visitados.Add(v);
                        Pila.Push(v);
                        CaminoPrim.Add(v);
                        DFS(Pila, Visitados, CaminoPrim);
                    }
                }
            }
            Graphics graphics = Graphics.FromImage(copia);
            LimpiarBitmap(copia, Color.Transparent);
            pictureBox1.Image = copia;
            BrochaAgente = new SolidBrush(Color.Red);
            List<Point> Linea = new List<Point>();
            Point punto = new Point();
            int b, c;
            listBox1.Items.Clear();
            LlenalistBox();
            listBox1.Update();
            Agente agente = new Agente(CaminoPrim[0], 1, CaminoPrim);
            while(true)
            {
                b = agente.GetcontAristas();
                bool Encontrado = false;
                foreach (Arista a in agente.getCamino()[b].getLa())
                {
                    if (b  < CaminoPrim.Count)
                    {
                        if (a.getVertex().getId() == agente.getCamino()[b + 1].getId())
                        {
                            Linea = a.getLinea();
                            Encontrado = true;
                        }
                    }
                }
                if (Encontrado == false)
                {
                    agente.SetcontPunto(Linea.Count-5);
                }
                c = agente.GetcontPuntos();
                if (Linea.Count - 5 <= c)
                    c = Linea.Count-1;
                punto = Linea[c];
                pictureBox1.Refresh();
                LimpiarBitmap(copia, Color.Transparent);
                DibujarCirculo(punto, BrochaAgente, copia);
                DibujarId(punto, drawBrush, copia, agente.getId());
                agente.SetcontPunto(agente.GetcontPuntos() + 7);
                if (agente.GetcontPuntos() >= Linea.Count)
                {
                    agente.SetcontPunto(0);
                    agente.SetcontAristas(agente.GetcontAristas() + 1);    
                }
                if (agente.GetcontAristas()+1 == CaminoPrim.Count)
                {
                    DibujarCirculo(punto, BrochaAgente, copia);
                    break;
                }
            }
            pictureBox1.Refresh();
        }

        private void BtnKruskal_Click(object sender, EventArgs e)
        {
            ArmKruskal = true;
            ArmPrim = false;
            pictureBox1.BackgroundImage = ARM;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            List<Vertice> Visitados = new List<Vertice>();
            Stack<Vertice> Pila = new Stack<Vertice>();
            CaminoKruskal = new List<Vertice>();
            int Buscado = comboBox1.SelectedIndex + 1;
            foreach (Vertice v in ArbolKruskal.getLv())
            {
                if (Buscado == v.getId())
                {
                    Pila.Push(v);
                    Visitados.Add(v);
                    CaminoKruskal.Add(v);
                    break;
                }
            }
            DFS(Pila, Visitados, CaminoKruskal);
            while (Visitados.Count != ArbolKruskal.getLv().Count)
            {
                foreach (Vertice v in ArbolKruskal.getLv())
                {
                    bool Band = false;
                    foreach (Vertice Bus in Visitados)
                    {
                        if (v.getId() == Bus.getId())
                        {
                            Band = true;
                            break;
                        }
                    }
                    if (Band == false)
                    {
                        Visitados.Add(v);
                        Pila.Push(v);
                        CaminoKruskal.Add(v);
                        DFS(Pila, Visitados, CaminoKruskal);
                    }
                }
            }
            Graphics graphics = Graphics.FromImage(copia);
            LimpiarBitmap(copia, Color.Transparent);
            pictureBox1.Image = copia;
            BrochaAgente = new SolidBrush(Color.Red);
            List<Point> Linea = new List<Point>();
            Point punto = new Point();
            int b, c;
            listBox1.Items.Clear();
            LlenalistBox();
            listBox1.Update();
            Agente agente = new Agente(CaminoKruskal[0], 1, CaminoKruskal);
            bool Vuelta = false;
            while (true)
            {
                b = agente.GetcontAristas();
                bool Encontrado = false;
                foreach (Arista a in agente.getCamino()[b].getLa())
                { 
                    if (b < CaminoKruskal.Count)
                    {
                        if (a.getVertex() == agente.getCamino()[b + 1] && b == 0)
                        {
                            bool Reversa = true;
                            foreach(Arista rev in AristasKruskal)
                            {
                                if (Buscado == rev.getVertexOrigen().getId())
                                {
                                    Reversa = false;
                                    Linea = a.getLinea();
                                    break;
                                }
                            }
                            if (Reversa == true && Vuelta==false)
                            {
                                Linea = a.getLinea();
                                Linea.Reverse();
                                Vuelta = true;
                            }
                            Encontrado = true;
                        }
                        if (a.getVertex() == agente.getCamino()[b + 1] && b!=0)
                        { 
                            if (b + 2 == CaminoKruskal.Count && Vuelta == true)
                            {
                                Linea = a.getLinea();
                                Linea.Reverse();
                                Vuelta = false;
                            }
                            else
                            {
                                Linea = a.getLinea();
                            }
                            Encontrado = true;
                        }
                    }
                }
                if (Encontrado == false)
                {
                    agente.SetcontPunto(Linea.Count - 5);
                }
                c = agente.GetcontPuntos();
                if (Linea.Count - 5 <= c)
                    c = Linea.Count - 1;
                punto = Linea[c];
                pictureBox1.Refresh();
                LimpiarBitmap(copia, Color.Transparent);
                DibujarCirculo(punto, BrochaAgente, copia);
                DibujarId(punto, drawBrush, copia, agente.getId());
                agente.SetcontPunto(agente.GetcontPuntos() + 7);
                if (agente.GetcontPuntos() >= Linea.Count)
                {
                    agente.SetcontPunto(0);
                    agente.SetcontAristas(agente.GetcontAristas() + 1);
                }
                if (agente.GetcontAristas() + 1 == CaminoKruskal.Count)
                {
                    DibujarCirculo(punto, BrochaAgente, copia);
                    break;
                }
            }
            pictureBox1.Refresh();
        }

        private void BtnARMporPrim_Click(object sender, EventArgs e)
        {
            Rectangle Dimensiones = new Rectangle(0, 0, Grafo.Width, Grafo.Height);
            System.Drawing.Imaging.PixelFormat formato = Grafo.PixelFormat;
            ARM = Grafo.Clone(Dimensiones, formato);
            TamAristasPrim.Items.Clear();
            pictureBox1.Image = Grafo;
            Vertice Elegido = null;
            int Buscado = comboBox1.SelectedIndex + 1;
            foreach (Vertice v in G.getLv())
            {
                if (Buscado == v.getId()) {
                    Elegido = v;
                }
            }
            Prim prim = new Prim(Elegido, G);
            List<Arista> Aristas = prim.getAristas();
            ArbolPrim = new Grafo();
            List<Vertice> listaVertices;
            listaVertices = ArbolPrim.getLv();
            foreach (Vertice v in G.getLv())
            {
                Vertice copia = new Vertice(v.getX(), v.getY(), v.getR(), v.getId());
                listaVertices.Add(copia);
            }
            Double Peso = 0;
            
            foreach (Arista a in Aristas)
            {
                foreach (Vertice v in listaVertices)
                {
                    if (a.getVertexOrigen().getId() == v.getId())
                    {
                        Arista copia1 = new Arista(a.getVertex(), a.getPond(), a.getVertexOrigen(), a.getLinea());
                        v.getLa().Add(copia1);
                    }
                    if (a.getVertex().getId() == v.getId())
                    {
                        Arista copia2= new Arista(a.getVertexOrigen(), a.getPond(), a.getVertex(), a.getLinea());
                        v.getLa().Add(copia2);
                    }
                }
                TamAristasPrim.Items.Add(a.getVertexOrigen().getId().ToString() + " - " + a.getVertex().getId().ToString() + " Peso: " + Math.Round(a.getPond()).ToString());
                Peso = Peso + a.getPond();
            }
            TamAristasPrim.Items.Add("Peso Acumulado= " + Math.Round(Peso).ToString());
            Graphics graphics = Graphics.FromImage(ARM);         
            Pen pluma = new Pen(Color.Green, 10);
            foreach (Arista a in Aristas)
            {
                graphics.DrawLine(pluma, a.getVertexOrigen().getX(), a.getVertexOrigen().getY(), a.getVertex().getX(), a.getVertex().getY());
            } 
            pictureBox1.Image = ARM;
            pictureBox1.Refresh();
            this.lblNumeroSubgrafos.Text = prim.getSubgrafos().ToString();
            this.BtnAgentePrim.Enabled = true;
            Rectangle Rectangulo = new Rectangle(0, 0, ARM.Width, ARM.Height);
            System.Drawing.Imaging.PixelFormat Format = ARM.PixelFormat;
            copia = ARM.Clone(Rectangulo, Format);
        }

        private void BtnARMporKruskal_Click(object sender, EventArgs e)
        {
            Kruskal kruskal = new Kruskal(G);
            AristasKruskal= kruskal.getCamino();
            ArbolKruskal = new Grafo();
            List<Vertice> listaVertices;
            listaVertices = ArbolKruskal.getLv();
            TamAristasKruskal.Items.Clear();
            foreach (Vertice v in G.getLv())
            {
                Vertice copia = new Vertice(v.getX(), v.getY(), v.getR(), v.getId());
                listaVertices.Add(copia);
            }
            foreach (Arista a in AristasKruskal)
            {
                foreach (Vertice v in listaVertices)
                {
                    if (a.getVertexOrigen().getId() == v.getId())
                    {
                        Arista copia1 = new Arista(a.getVertex(), a.getPond(), a.getVertexOrigen(), a.getLinea());
                        v.getLa().Add(copia1);
                    }
                    if (a.getVertex().getId() == v.getId())
                    {
                        Arista copia2 = new Arista(a.getVertexOrigen(), a.getPond(), a.getVertex(), a.getLinea());
                        v.getLa().Add(copia2);
                    }
                }
            }
            Double Acumulado=0;
            foreach(Arista a in AristasKruskal)
            { 
                TamAristasKruskal.Items.Add(a.getVertexOrigen().getId().ToString() + " - " + a.getVertex().getId().ToString()+" Peso: "+Math.Round(a.getPond()).ToString());
                Acumulado = Acumulado + Math.Round(a.getPond());
            }
            TamAristasKruskal.Items.Add("Peso Acumulado= " + Math.Round(Acumulado).ToString());
            Graphics graphics = Graphics.FromImage(ARM);
            pictureBox1.Image = ARM;
            Pen pluma = new Pen(Color.Purple, 10);
            foreach (Arista a in AristasKruskal)
            {
                graphics.DrawLine(pluma, a.getVertexOrigen().getX(), a.getVertexOrigen().getY(), a.getVertex().getX(), a.getVertex().getY());
            }
            pictureBox1.Refresh();
            Rectangle Rectangulo = new Rectangle(0, 0, ARM.Width, ARM.Height);
            System.Drawing.Imaging.PixelFormat Format = ARM.PixelFormat;
            copia = ARM.Clone(Rectangulo, Format);
            this.lblNumeroSubgrafos.Text = kruskal.getSubgrafos().ToString();
            this.BtnAgenteKruskal.Enabled = true;
        }

        void LimpiarBitmap(Bitmap bmp, Color c) {
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(c);
        }

        void LlenalistBox(){
            string s = "";
            if (ArmPrim == true && CaminoPrim!=null)
            {
                foreach (Vertice v in CaminoPrim)
                {
                    s += v.getId().ToString() + "-";
                }
                listBox1.Items.Add(s);
            }
            if (ArmKruskal == true && CaminoKruskal != null)
            {
                foreach (Vertice v in CaminoKruskal)
                {
                    s += v.getId().ToString() + "-";
                }
                listBox1.Items.Add(s);
            }
        }

        public void DFS(Stack<Vertice> Pila, List<Vertice> Visitados,List<Vertice> Camino)
        {
            Vertice v_act=Pila.Pop();
            foreach (Arista a in v_act.getLa())
            {
                bool Band = false;
                foreach (Vertice v in Visitados)
                {
                    if (v.getId() == a.getVertex().getId())
                    {
                        Band = true;
                        break;
                    }
                }
                if (Band == false)
                {
                    if (ArmPrim == true)
                    {
                        foreach (Vertice Ref in ArbolPrim.getLv())
                        {
                            if (a.getVertex().getId() == Ref.getId())
                            {
                                Visitados.Add(a.getVertex());
                                Pila.Push(Ref);
                                Camino.Add(a.getVertex());
                                DFS(Pila, Visitados, Camino);
                                Camino.Add(a.getVertexOrigen());
                            }
                        }
                    }
                    if (ArmKruskal == true)
                    {
                        foreach (Vertice Ref in ArbolKruskal.getLv())
                        {
                            if (a.getVertex().getId() == Ref.getId())
                            {
                                Visitados.Add(a.getVertex());
                                Pila.Push(Ref);
                                Camino.Add(a.getVertex());
                                DFS(Pila, Visitados, Camino);
                                Camino.Add(a.getVertexOrigen());
                            }
                        }
                    }
                }
                
            }
        }
    }
}