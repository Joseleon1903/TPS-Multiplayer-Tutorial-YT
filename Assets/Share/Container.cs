using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    [System.Serializable]
    public class ContainerItem {

        public System.Guid Id;
        public string Name;
        public int Maximum;

        public ContainerItem() {
            Id = System.Guid.NewGuid();
        }

        private int amountTaken;

        public int Remaning { get { return Maximum - amountTaken; } }

        internal int Get(int value)
        {
            if ((amountTaken + value) > Maximum) {
                int toMuch = (amountTaken + value) - Maximum;
                amountTaken = Maximum;
                return value - toMuch;
            }

            amountTaken += value;
            return value;
        }
    }

    public List<ContainerItem> items;

    void Awake() {

        items = new List<ContainerItem>();
    }


    public System.Guid Add(string name , int maximum) {

        items.Add(new ContainerItem
        {
            Name = name,
            Maximum = maximum
        });

        return items.Last().Id;
    }


    public int TakeFromConteiners(System.Guid id , int amount) { 

        var container = items.Where( x=> x.Id == id).FirstOrDefault();

        if (container == null)
            return -1;

        return container.Get(amount);
    }
   
}
