using App1.Clases;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Servicios
{
    public class ServicioConsultaIP
    {
        public static async Task<Principal> ConsultarIp() {

            var principal = new Principal(); //Creamos el objeto

            var conexion = "http://ifconfig.me"; //URL DE LA PETICION

            //Lanzamos "un subproceso (con USING)" y preparamos nuestro cliente HTTP
            using (var cliente = new HttpClient()) {

            //Lanzamos "una petición (con AWAIT para evitar problemas)" y lanzamos el cliente HTTP pasandole la URL de la petición 
            var peticion = await cliente.GetAsync(conexion);
            

                //Nos aseguramos de que exista algo dentro de la petición
                if (peticion != null) {

                   
                    var request = peticion.Content.ReadAsStringAsync().Result; //Almacenamos la lectura de la consulta realizada
                    
                    string source = request.ToString(); //Pasamos la request a una string para que no muestre caracter a caracter

                    //Comprobamos que tengamos contenido en la variable "source"
                    if (source != null) { 

                    //Pasamos la String que contiene la peticion HTTP a una LIST en el que estará separada línea a línea, para poder trabajar mejor con esta utilizando un foreach 
                       List<string> listaTextoP = source.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                   
                        
                        foreach (var item in listaTextoP){ //Recorremos la LISTA
                           
                            if (item.Contains("ip_addr:")) { //Comprobamos si ITEM tiene la STRING que buscamos

                                var ip = item.ToString().Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                                principal.LblDos = (ip[1].ToString()); //Seteamos el nombre de LblDos
                            }
                        }//Fin del foreach

                    }//Fin de if request!=null

                }//Fin de if peticion!=null

               
               
            
            }//Fin del USING

            return principal;
            
        }//Fin del metodo ConsultarIp

    }//Fin de la Clase ServicioConsultaIP
}
