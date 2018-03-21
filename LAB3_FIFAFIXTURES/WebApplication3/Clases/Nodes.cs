using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class Nodes<T> where T : IComparable
    {
        private T data;
        private NodeList<T> childern = null;

        public Nodes() { }
        public Nodes(T data) : this(data, null) { }
        public Nodes(T data, NodeList<T> childern)
        {
            this.data = data;
            this.childern = childern;
        }

        public T Value
        {
            get { return data; }
            set { data = value; }
        }
        protected NodeList<T> Children
        {
            get { return childern; }
            set { childern = value; }
        }
    }

    public class NodeList<E> : Collection<Nodes<E>> where E : IComparable
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                Items.Add(default(Nodes<E>));
        }


        public Nodes<E> FindByValue(E value)
        {
            foreach (Nodes<E> node in Items)
                if (node.Value.Equals(value))
                    return node;

            return null;
        }
    }
    public class Partidos <T> where T : IComparable
    {      
        public int NoPartido { get; set; }        
        public string FechaPartido { get; set; }        
        public string Grupo { get; set; }       
        public string Pais1 { get; set; }
        public string Pais2 { get; set; }      
        public string Estadio { get; set; }
    }
}