using System;

namespace StrategyPatternDotNetCore
{

    public interface ICorrerMaratonBehavior
    {
        void Correr();
    }
    //comportamientos
    public class CorrerHabiendoFondeado : ICorrerMaratonBehavior
    {
        public void Correr()
        {
            Console.WriteLine("Habiendo metido fondo vas a llegar bien, con aire y sin dolor muscular.");
        }
    }

    public class CorrerSinHaberFondeado : ICorrerMaratonBehavior
    {
        public void Correr()
        {
            Console.WriteLine("Vas a pincharte a los 30km, vas a sufrir, y desear no haberte anotado.");
        }
    }

    public class CorrerSoloHabiendoMetidoVelocidad : ICorrerMaratonBehavior
    {
        public void Correr()
        {
            Console.WriteLine("Vas a empezar muy bien, pero vas a pincharte a los 15km y vas a sufrir, y desear no haberte anotado.");
        }
    }

    public abstract class Corredor
    {
        protected ICorrerMaratonBehavior corredorBehavior;

        public void correrMaraton()
        {
            corredorBehavior.Correr();
        }
        public void setCorredorBehavior(ICorrerMaratonBehavior beh)
        {
            this.corredorBehavior = beh;
        }
    }
    //Nuestros compañeros
    public class Santiago : Corredor
    {
        public Santiago()
        {
            this.corredorBehavior = new CorrerSinHaberFondeado();
        }
    }

    public class Cristian : Corredor
    {
        public Cristian()
        {
            this.corredorBehavior = new CorrerSoloHabiendoMetidoVelocidad();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Corredor Santi = new Santiago();
            Corredor Cris = new Cristian();

            Santi.correrMaraton();
            Cris.correrMaraton();

            Santi.setCorredorBehavior(new CorrerHabiendoFondeado());
            Cris.setCorredorBehavior(new CorrerHabiendoFondeado());

            Santi.correrMaraton();
            Cris.correrMaraton();

            Console.ReadKey();
        }
    }
}