using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    public class Model
    {
        private string _modelobj;
        private List<Observer> _observer = new List<Observer>();
        
        public string getModel()
        {
            return _modelobj;
        }
        public void setModel(string _modelobj)
        {
            this._modelobj = _modelobj;
            this.notifyStateChange();
        }

        public void attach(Observer observer)
        {
            _observer.Add(observer);
        }

        public void notifyStateChange()
        {
            foreach (Observer observer in _observer)
            {
                observer.update();
            }
        }
    }

    public abstract class Observer
    {        
        public Model model;
        public abstract void update();
    }

    public class ConcreteObserver : Observer
    {
        public ConcreteObserver(Model model)
        {
            this.model = model;
            base.model.attach(this);
        }

        public override void update()
        {           
            Console.WriteLine("Value changed to: "+ model.getModel());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Model _modelobj = new Model();
            ConcreteObserver obj = new ConcreteObserver(_modelobj);
            _modelobj.setModel("hi");
            _modelobj.setModel("hi1");
            Console.Read();
        }
    }
}
