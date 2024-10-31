using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        private string _name;
        public virtual int Pattes => 4;

        public event Action OnDie;

        public Chat(string name){
            _name = name;
        }

        internal string Name => _name;

        public override string Crier(){
            if(!this.IsFed)
            {
                return "Miaou (j'ai faim)";
            } 
            else
            {
                if(Food is Poisson){
                    return "Miaou (Le poisson etait bon)";
                }
                return "Miaou (c'est bon laisse moi tranquille humain)";
            }
            
        }

        public void Die(){
            OnDie?.Invoke();
        }
    }
}
