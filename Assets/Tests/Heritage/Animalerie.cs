using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Animalerie
    {
        public List<Animal> Animals = new List<Animal>();
        public event Action<Animal> OnAddAnimal;

        //Manipulate List 
        public void AddAnimal(Animal a){
            Animals.Add(a);

            _OnAddAnimal(a);
        }

        public bool Contains(Animal a){
            return Animals.Contains(a);
        }

        public Animal GetAnimal(int index){
            return Animals[index];
        }

        //Feed
        public void FeedAll(){
            foreach(var animal in Animals){
                animal.Feed();
            }
        }

        //ZOOEvent
        private void _OnAddAnimal(Animal a){
            OnAddAnimal?.Invoke(a);

            GetInteractionsWithOthersAnimals(a);
        }

        //Interaction
        public void GetInteractionsWithOthersAnimals(Animal newComer){
            foreach(var animal in Animals){
                
                //Relation de mon nv arrivant avec la basse-cour
                bool PoissonWithCat = newComer is Poisson && animal is Chat;
                bool CatWithPoisson = newComer is Chat  && animal is Poisson;

                if(CatWithPoisson){
                    if(newComer is ChatQuiBoite)
                    {
                        continue;
                    }
                    newComer.FeedWith(animal);
                    break;
                }
                else if (PoissonWithCat){
                    if(animal is ChatQuiBoite){
                        continue;
                    }
                    animal.FeedWith(newComer);
                    break;
                }
            }
        }
    }
}
