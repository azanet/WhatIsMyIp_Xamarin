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

            var conexion = $"https://ifconfig.me"; //URL DE LA PETICION

            //Creamos un objeto HttpClient  para utilizarlo en nuestras consultas
            HttpClient cliente = new HttpClient();
  
            //Almacenamos la lectura de la consulta realizada (que será un HTML)
   
                    //Recogiendo cuerpo de la peticion realizada
                    string responseBody = await cliente.GetStringAsync(conexion);
                    //Console.WriteLine(responseBody);

                    //Comprobamos que el "cuerpo" tenga contenido
                    if (responseBody != null) { 

                    //Pasamos la String que contiene la peticion HTTP a una LIST en el que estará separada línea a línea, para poder trabajar mejor con esta utilizando un foreach 
                       List<string> listaTextoP = responseBody.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                   
                        
                        foreach (var item in listaTextoP){ //Recorremos la LISTA
                           
                            if (item.Contains("ip_addr:")) { //Comprobamos si ITEM tiene la STRING que buscamos

                                var ip = item.ToString().Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                                principal.LblDos = (ip[1].ToString()); //Seteamos el nombre de LblDos
                            }
                        }//Fin del foreach


                }//Fin de if peticion!=null


            return principal;
            
        }//Fin del metodo ConsultarIp

    }//Fin de la Clase ServicioConsultaIP
}
