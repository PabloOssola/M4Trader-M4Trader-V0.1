using System;

namespace M4Trader.ordenes.server.CQRSFramework
{

    public class MAEDateTimeTools
    {

        public static DateTime DateTimeAdd(DateTime fecha, int incremento, string Unidad)
        {
            TimeSpan duration = new TimeSpan(0, 0, 0, 0);

            switch (Unidad) //días, horas, minutos, segundos y milisegundos 
            {
                case "d":
                    duration = new TimeSpan(incremento, 0, 0, 0);
                    break;
                case "h":
                    duration = new TimeSpan(0, incremento, 0, 0);
                    break;
                case "m":
                    duration = new TimeSpan(0, 0, incremento, 0);
                    break;
                case "s":
                    duration = new TimeSpan(0, 0, 0, incremento);
                    break;
            }

            return fecha.Add(duration);
        }
    }
}
