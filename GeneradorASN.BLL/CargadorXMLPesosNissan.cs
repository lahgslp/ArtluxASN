using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeneradorASN.BLL
{
    public class MedidasArticulo
    {
        public string Clave = "";
        public decimal Peso = 0.0M;
        public decimal Largo = 0.0M;
        public decimal Ancho = 0.0M;
        public decimal Altura = 0.0M;
        public int PiezasXcaja = 0;
    }

    class CargadorXMLPesosNissan
    {
        static public Hashtable ObtenerPesos()
        {
            Hashtable tiempos = new Hashtable();
            XmlDocument doc = new XmlDocument();
            
            try
            {
                doc.Load("PesosNissan.xml");
            }
            catch (Exception e)
            {
                throw new Exception("No se ha encontrado el archivo 'PesosNissan.xml', favor de reinstalar aplicacion o contactar a " + ConfigurationManager.AppSettings["CorreoSoporte"] + ". " + e.Message);
            }
            XmlElement xelRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xelRoot.SelectNodes("/Pesos/Articulo");
            foreach (XmlNode Articulo in xmlNodes)
            {
                MedidasArticulo Medida = new MedidasArticulo();
                try
                {
                    //dias = Convert.ToInt32(Articulo["TiempoLogistica"].InnerText);
                    Medida.Peso = Convert.ToDecimal (Articulo["Peso"].InnerText);
                    Medida.Largo = Convert.ToDecimal(Articulo["Largo"].InnerText);
                    Medida.Ancho = Convert.ToDecimal(Articulo["Ancho"].InnerText);
                    Medida.Altura = Convert.ToDecimal(Articulo["Altura"].InnerText);
                    Medida.PiezasXcaja = Convert.ToInt32 (Articulo["PiezasCaja"].InnerText);
                }
                catch (Exception e)
                {
                    throw new Exception("Formato incorrecto en archivo 'PesosNissan.xml', favor de validar nodo '" + Articulo.OuterXml + "' o contactar a " + ConfigurationManager.AppSettings["CorreoSoporte"] + ". " + e.Message);
                }
                try
                {
                    Medida.Clave = Articulo["ClaveAlterna"].InnerText;
                    tiempos[Articulo["ClaveAlterna"].InnerText] = Medida;
                }
                catch (Exception e)
                {
                    throw new Exception("'Clave Alterna de Articulo' duplicada en archivo 'PesosNissan.xml', favor de validar nodo '" + Articulo.OuterXml + "' o contactar a " + ConfigurationManager.AppSettings["CorreoSoporte"] + ". " + e.Message);
                }
            }
            return tiempos;
        }
    }

    
}
