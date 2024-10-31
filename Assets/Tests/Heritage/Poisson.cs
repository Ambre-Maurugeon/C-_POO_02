using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Poisson : Animal
    {
        private string _name;

        public Poisson(string name){
            _name = name + " le poisson";
        }

        internal string Name => _name;

        public int Pattes => 0;

    }
}
