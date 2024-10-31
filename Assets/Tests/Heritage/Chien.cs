using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chien : Animal
    {
        public string _name;

        public Chien(string name){
            _name = name;
        }

        public override string Crier(){
            if(!this.IsFed)
            {
                return "Ouaf (j'ai faim)";
            } 
            else
            {
                return "Ouaf (viens on joue ?)";
            }
        }
    }
}
