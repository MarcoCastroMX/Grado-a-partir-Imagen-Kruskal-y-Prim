
using Actividad_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad_4
{
    public class Agente
    {
        Vertice refOrigen;
        Vertice Actual;
        int id;
        List<Vertice> Camino = new List<Vertice>();
        int contAristas;
        int contPuntos;

        public Agente(Vertice Inicio,int numero,List<Vertice> ARM){
            refOrigen = Inicio;
            Actual = Inicio;
            contAristas = 0;
            contPuntos = 0;
            id = numero;
            Camino = ARM;
        }
        public List<Vertice> getCamino()
        {
            return Camino;
        }
        public Vertice GetRefOrigen()
        {
            return refOrigen;
        }
        public int GetcontAristas()
        {
            return contAristas;
        }
        public void SetcontAristas(int numero)
        {
            contAristas = numero;
        }
        public int GetcontPuntos()
        {
            return contPuntos;
        }
        public void SetcontPunto(int numero)
        {
            contPuntos = numero;
        }
        public int getId()
        {
            return id;
        }
    }
}
