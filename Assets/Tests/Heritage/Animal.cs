using System;

namespace TU_Challenge.Heritage
{
    public class Animal
    {
        public bool IsFed { get; private set; } = false;

        public Animal Food { get; private set; }

        
        public virtual string Crier()
        {
            return "";
        }

        public void Feed()
        {
            IsFed = true; 
        } 

        public void FeedWith(Animal a){
            Feed();
            Food = a;

            Kill(a);
        }


        //Alive (OR NOT) 
        private bool _isAlive = true;

        private void Kill(Animal a){
            a._isAlive = false;
        }

        public bool IsAlive => _isAlive;


    }

}
