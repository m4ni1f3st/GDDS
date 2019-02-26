using System;
using System.ServiceProcess;
using System.Timers;


namespace GDDS
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        Archivo local = new Archivo();


        public Service1()
        {
            InitializeComponent();
        }

        internal void IniciarServicio(string [] args)
        {
            this.OnStart(args);
        }

        internal void TerminarServicio()
        {
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            local.grabar("Servicio iniciado: " + DateTime.Now);
            Conexiones loc = new Conexiones();
            loc.obtener_mail();
            //Correo loc = new Correo();
            //loc.EnviarCorreo2();
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds  
            timer.Enabled = true;
        }
        protected override void OnStop()
        {
            local.grabar("Servicio esta detenido " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            local.grabar("Service is recall at " + DateTime.Now);
        }

        
    }
}

