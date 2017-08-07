using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Compound unknown = new Compound("unknown");
            unknown.Display();

            Compound water = new RichCompound("water");
            water.Display();

            Compound benzene = new RichCompound("benzene");
            benzene.Display();

            Compound ethanal = new RichCompound("Ethanal");
            ethanal.Display();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'compound' class
    /// </summary>
    class Compound
    {
        protected string _chemical;
        protected float _boilingPoint;
        protected float _meltingPoint;
        protected double _molecularWeight;
        protected string _molecularFormular;

        public Compound(string chemical)
        {
            this._chemical = chemical;
        }

        public virtual void Display()
        {
            Console.WriteLine("\nCompound: {0} ------ ", _chemical);
        }
    }

    class RichCompound : Compound
    {
        private ChemicalDatabank _bank;

        public RichCompound(string name) : base(name)
        {

        }
        public override void Display()
        {
            _bank = new ChemicalDatabank();

            _boilingPoint = _bank.getCriticalPoint(_chemical, "B");
            _meltingPoint = _bank.getCriticalPoint(_chemical, "M");
            _molecularWeight = _bank.GetMolecularWeight(_chemical);
            _molecularFormular = _bank.GetMolecularStructure(_chemical);

            base.Display();
            Console.WriteLine(" Formula: {0}", _molecularFormular);
            Console.WriteLine(" Weight : {0}", _molecularWeight);
            Console.WriteLine(" Melting Pt: {0}", _meltingPoint);
            Console.WriteLine(" Boiling Pt: {0}", _boilingPoint);
        }
    }

    internal class ChemicalDatabank
    {
        internal float getCriticalPoint(string compound, string point)
        {
            if(point.ToUpper() == "M")
            {
                switch(compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "ethanal": return -114.1f;
                    default: return 0f;
                }
            }

            // Boiling Point
            else
            {
                switch (compound.ToLower())
                {
                    case "water": return 100.0f;
                    case "benzene": return 80.1f;
                    case "ethanol": return 78.3f;
                    default: return 0f;
                }
            }
        }

        internal string GetMolecularStructure(string compound)
        {
            switch(compound.ToLower())
            {
                case "water": return "H2O";
                case "benzene": return "C6H6";
                case "ethanal": return "C2H5OH";
                default: return "";                 
            }

        }

        internal double GetMolecularWeight(string compound)
        {
            switch(compound.ToLower())
            {
                case "water": return 18.015;
                case "benzene": return 78.1134;
                case "ethanal": return 46.0688;
                default: return 0d;
            }
        }
    }
}
