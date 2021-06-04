using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorJugoPomeloController.Controllers
{
    public class Distribuciones
    {
        public double GeneradorGUAdictivo()
        {
            int n1, n2, mod;
            Random rnd = new Random();
            n1 = rnd.Next(1000, 9999);
            n2 = rnd.Next(1000, 9999);
            mod = rnd.Next(1000,9999);
            double x, u; 
            x = (n2 + n1) % mod;
            u = x / (mod - 1);
            return u;

        }

        public double Normal(double m, double d)
        {
            double u;
            double sum = 0;
            for(int i=1; i<=12; i++)
            {
                u = GeneradorGUAdictivo();
                sum = sum + u;
            }
            return d * (sum -6) +m;
        }

        public double Uniforme(double a, double b)
        {
            double v,u;
            u = GeneradorGUAdictivo();
            v = a + (b - a) * u;
            return v;
        }
    }
}
