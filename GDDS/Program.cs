using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace GDDS
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main(string [] args)
        {
            //Verificamos si es una aplicación interactiva
            if (Environment.UserInteractive)
            {
                //Creamos una instancia del servicio
                Service1 service1 = new Service1();
                service1.IniciarServicio(args);
                //Iniciamos el método inicial del servicio
                //service1.IniciarServicio(args);

                //Creamos una condición de parada para el servicio
                Console.WriteLine("Escriba STOP para terminar el servicio");
                string ingreso = Console.ReadLine();

                if (ingreso.Equals("STOP", StringComparison.OrdinalIgnoreCase))
                    Console.Write("hqweho");
                    //service1.TerminarServicio();
            }
            else
            {
                //Flujo Normal de un servicio Windows
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
